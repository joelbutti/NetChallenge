using MediatR;
using NetChallenge.Domain.Dtos;

namespace NetChallenge.Application.UseCases.Commands.AddBook
{
    public record struct AddBookCommand(string LocationName, string OfficeName, DateTime DateTime, int DurationInMinutes, string UserName) : IRequest<StandardResponse>;
}
