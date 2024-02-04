using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IApplicationDbContext _context;

        public OfficeRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Office> AsEnumerable() => _context.Offices.AsNoTracking();

        public async Task Add(Office item)
        {
            await _context.Offices.AddAsync(item);

            await _context.SaveChangesAsync();
        }
    }
}