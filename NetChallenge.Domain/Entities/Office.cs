namespace NetChallenge.Domain.Entities
{
    public class Office
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public List<string> AvailableResources { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}