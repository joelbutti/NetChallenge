using MediatR;
using NetChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Exceptions.OfficeErrors
{
    public class DuplicateOfficeException(string locationName, string officeName) : 
        Exception($"There is already a office in location '{locationName}' with the name '{officeName}'")
    {
    }
}
