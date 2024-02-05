using Microsoft.EntityFrameworkCore;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Office> Offices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
