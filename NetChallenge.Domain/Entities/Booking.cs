using NetChallenge.Domain.DomainEvents.Booking;
using NetChallenge.Domain.Primitives;
using NetChallenge.Domain.ValueObjects;

namespace NetChallenge.Domain.Entities
{
    public sealed class Booking : AggregateRoot
    {
        public Guid OfficeId { get; private set; }
        public DateTime DateTime { get; private set; }
        public Duration Duration { get; private set; }
        public UserName UserName { get; private set; }

        protected Booking(Guid id) : base(id) { }

        private Booking(Guid id, Guid officeId, DateTime dateTime, TimeSpan duration, string userName) : base(id) 
        {
            OfficeId = officeId;
            DateTime = dateTime;
            Duration = Duration.Create(duration);
            UserName = UserName.Create(userName);

            Raise(new BookingCreatedDomainEvent(userName, dateTime, duration));
        }

        public static Booking Create(Guid officeId, DateTime dateTime, TimeSpan duration, string userName)
        {
            return new Booking(Guid.NewGuid(), officeId, dateTime, duration, userName);
        }
    }
}