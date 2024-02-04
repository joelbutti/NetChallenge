using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IApplicationDbContext _context;

        public BookingRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> AsEnumerable() => _context.Bookings.AsNoTracking();

        public async Task Add(Booking item)
        {
            _context.Bookings.Add(item);

            await _context.SaveChangesAsync();
        }
    }
}