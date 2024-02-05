using NetChallenge.Domain.DomainEvents.Location;
using NetChallenge.Domain.Primitives;
using NetChallenge.Domain.ValueObjects;

namespace NetChallenge.Domain.Entities
{
    public sealed class Location : AggregateRoot
    {
        public Name Name { get; private set; }
        public Neighborhood Neighborhood { get; private set; }
        public List<Office> Offices { get; private set; } = new();

        protected Location(Guid id) : base(id){ }

        private Location(Guid id, string name, string neighborhood) : base(id) 
        {
            Name = Name.Create(name);
            Neighborhood = Neighborhood.Create(neighborhood);

            Raise(new LocationCreatedDomainEvent(name));
        }

        public static Location Create(string name, string neighborhood)
        {
            return new Location(Guid.NewGuid(), name, neighborhood);
        }
    }
}