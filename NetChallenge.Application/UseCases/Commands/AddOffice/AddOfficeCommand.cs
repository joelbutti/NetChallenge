using MediatR;
using NetChallenge.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Commands.AddOffice
{
    public record struct AddOfficeCommand(string LocationName, string Name, int MaxCapacity, IEnumerable<string> AvailableResources) : IRequest<StandardResponse>;
}
