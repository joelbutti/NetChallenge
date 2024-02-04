using NetChallenge.Domain.Primitives;

namespace NetChallenge.Domain.Entities
{
    public sealed class Office : AggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid LocationId { get; private set; }
        public string Name { get; private set; }
        public int MaxCapacity { get; private set; }
        public List<string> AvailableResources { get; private set; }
        public List<Booking> Bookings { get; private set; } = new();

        private Office(Guid locationId, string name, int maxCapacity, List<string> availableResources)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty or null.");
            }

            if (maxCapacity <= 0)
            {
                throw new ArgumentException("Capacity should be greater than 0.");
            }

            Id = Guid.NewGuid();
            LocationId = locationId;
            Name = name;
            MaxCapacity = maxCapacity;
            AvailableResources = availableResources ?? new List<string>();
        }

        public static Office Create(Guid locationId, string name, int maxCapacity, List<string> availableResources)
        {
            return new Office(locationId, name, maxCapacity, availableResources);
        }
    }
}