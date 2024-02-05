using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Exceptions.OfficeErrors
{
    public class OfficeNotFoundException(string locationName, string officeName) : Exception($"Office '{officeName}' in Location '{locationName}' not found.")
    {
    }
}
