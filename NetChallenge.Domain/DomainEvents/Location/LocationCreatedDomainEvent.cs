using NetChallenge.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.DomainEvents.Location
{
    public sealed record LocationCreatedDomainEvent(string LocationName) : IDomainEvent;
}
