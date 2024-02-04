namespace NetChallenge.Domain.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public List<Office> Offices { get; set; } = new();
    }
}