using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Exceptions.LocationErrors
{
    public class DuplicateLocationException(string locationName) : Exception($"There is already a location with the name '{locationName}'")
    {
    }
}
