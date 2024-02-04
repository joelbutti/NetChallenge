using NetChallenge.Domain.Primitives;

namespace NetChallenge.Domain.Entities
{
    public sealed class Booking : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid OfficeId { get; private set; }
        public DateTime DateTime { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string UserName { get; private set; }

        private Booking(Guid officeId, DateTime dateTime, TimeSpan duration, string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            if (duration <= TimeSpan.Zero)
            {
                throw new ArgumentException("Duration should be greater than 0.");
            }

            Id = Guid.NewGuid();
            OfficeId = officeId;
            DateTime = dateTime;
            Duration = duration;
            UserName = userName;
        }

        public static Booking Create(Guid officeId, DateTime dateTime, TimeSpan duration, string userName)
        {
            return new Booking(officeId, dateTime, duration, userName);
        }
    }
}