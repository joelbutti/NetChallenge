using System.Collections.Generic;

namespace NetChallenge.Dtos.Input
{
    public class AddOfficeRequest
    {
        public string LocationName { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public IEnumerable<string> AvailableResources { get; set; }
    }
}