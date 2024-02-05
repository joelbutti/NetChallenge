using NetChallenge.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.DomainEvents.Booking
{
    public sealed record BookingCreatedDomainEvent(string UserName, DateTime Date, TimeSpan Duration) : IDomainEvent;
}
