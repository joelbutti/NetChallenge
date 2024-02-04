using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Infrastructure.Persistence.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly List<Booking> Bookings = [];

        public BookingRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> AsEnumerable() => Bookings;

        public void Add(Booking item)
        {
            Bookings.Add(item);
        }

        public IEnumerable<Booking> AsEnumerableDb() => _context.Bookings
            .AsNoTracking();

        public async Task AddDb(Booking item)
        {
            _context.Bookings.Add(item);

            await _context.SaveChangesAsync();
        }
    }
}