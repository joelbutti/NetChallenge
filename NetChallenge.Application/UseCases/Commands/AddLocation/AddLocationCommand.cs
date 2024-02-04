using MediatR;
using NetChallenge.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Commands.AddLocation
{
    public record struct AddLocationCommand(string Name, string Neighborhood) : IRequest<StandardResponse>;
}
