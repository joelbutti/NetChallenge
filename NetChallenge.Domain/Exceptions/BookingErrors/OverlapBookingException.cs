using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Exceptions.BookingErrors
{
    public class OverlapBookingException(DateTime date) : Exception($"Booking overlaps with an existing reservation at {date}.")
    {
    }
}
