using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly List<Office> Offices = [];

        public OfficeRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Office> AsEnumerable() => Offices;

        public void Add(Office item)
        {
            Offices.Add(item);
        }

        public IEnumerable<Office> AsEnumerableDb() => _context.Offices
                    .AsNoTracking()
                    .Include(o => o.Bookings);

        public async Task AddDb(Office item)
        {
            await _context.Offices.AddAsync(item);

            await _context.SaveChangesAsync();
        }
    }
}