using NetChallenge.Domain.Primitives;

namespace NetChallenge.Domain.Entities
{
    public sealed class Location : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Neighborhood { get; private set; }
        public List<Office> Offices { get; private set; } = new();

        private Location(string name, string neighborhood)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(neighborhood))
            {
                throw new ArgumentException("Neighborhood cannot be null or empty.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Neighborhood = neighborhood;
        }

        public static Location Create(string name, string neighborhood)
        {
            return new Location(name, neighborhood);
        }
    }
}