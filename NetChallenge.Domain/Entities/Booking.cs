namespace NetChallenge.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid OfficeId { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string UserName { get; set; }
        public Office Office { get; set; } = new();
    }
}