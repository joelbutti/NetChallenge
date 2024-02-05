using NetChallenge.Domain.DomainEvents.Office;
using NetChallenge.Domain.Primitives;
using NetChallenge.Domain.ValueObjects;

namespace NetChallenge.Domain.Entities
{
    public sealed class Office : AggregateRoot
    {
        public Guid LocationId { get; private set; }
        public Name Name { get; private set; }
        public MaxCapacity MaxCapacity { get; private set; }
        public List<string> AvailableResources { get; private set; }
        public List<Booking> Bookings { get; private set; } = new();

        protected Office(Guid id) : base(id) { }

        private Office(Guid id, Guid locationId, string name, int maxCapacity, List<string> availableResources) : base(id)
        {
            LocationId = locationId;
            Name = Name.Create(name);
            MaxCapacity = MaxCapacity.Create(maxCapacity);
            AvailableResources = availableResources ?? new List<string>();

            Raise(new OfficeCreatedDomainEvent(name));
        }

        public static Office Create(Guid locationId, string name, int maxCapacity, List<string> availableResources)
        {
            return new Office(Guid.NewGuid(), locationId, name, maxCapacity, availableResources);
        }
    }
}