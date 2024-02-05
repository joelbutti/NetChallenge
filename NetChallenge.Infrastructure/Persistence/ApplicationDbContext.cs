using MediatR;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Common.Interfaces;
using NetChallenge.Domain.Entities;
using NetChallenge.Domain.Primitives;

namespace NetChallenge.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;

        public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .SelectMany(x =>
                {
                    var domainEvents = x.GetDomainEvents();

                    x.ClearDomainEvents();

                    return domainEvents;
                })
                .ToList();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
