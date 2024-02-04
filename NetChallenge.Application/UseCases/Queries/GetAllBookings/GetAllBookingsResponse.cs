using NetChallenge.Domain.Dtos;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllBookings
{
    public record struct GetAllBookingsResponse(string Message, IEnumerable<BookingDto> Bookings);
}
