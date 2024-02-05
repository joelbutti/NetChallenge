using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Primitives
{
    public interface IDomainEvent : INotification
    {
    }
}
