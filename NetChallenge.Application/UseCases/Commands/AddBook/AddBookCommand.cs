using MediatR;
using NetChallenge.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Commands.AddBook
{
    public record struct AddBookCommand(string LocationName, string OfficeName, DateTime DateTime, int DurationInMinutes, string UserName) : IRequest<StandardResponse>;
}
