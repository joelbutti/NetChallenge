using NetChallenge.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.DomainEvents.Office
{
    public sealed record OfficeCreatedDomainEvent(string OfficeName) : IDomainEvent;
}
