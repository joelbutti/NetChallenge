using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Common.Interfaces;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly List<Location> Locations = [];

        public LocationRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Location> AsEnumerable() => Locations;

        public void Add(Location item)
        {
            Locations.Add(item);
        }

        public IEnumerable<Location> AsEnumerableDb() => _context.Locations
            .AsNoTracking()
            .Include(l => l.Offices);

        public async Task AddDb(Location item)
        {
            await _context.Locations.AddAsync(item);

            await _context.SaveChangesAsync();
        }
    }
}