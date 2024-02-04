using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IApplicationDbContext _context;

        public LocationRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Location> AsEnumerable() => _context.Locations
            .AsNoTracking()
            .Include("Offices");

        public async Task Add(Location item)
        {
            await _context.Locations.AddAsync(item);

            await _context.SaveChangesAsync();
        }
    }
}