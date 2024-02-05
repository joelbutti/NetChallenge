using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Exceptions.LocationErrors
{
    public class LocationNotFoundException(string locationName) : Exception($"Location '{locationName}' not found.")
    {
    }
}
