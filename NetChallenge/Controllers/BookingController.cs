using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.UseCases.Commands.AddBook;
using NetChallenge.Application.UseCases.Commands.AddLocation;
using NetChallenge.Application.UseCases.Queries.GetAllBookings;
using NetChallenge.Application.UseCases.Queries.GetAllOffices;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dto.Output;

namespace NetChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ISender _mediator;

        public BookingController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<StandardResponse> AddBook([FromBody] AddBookCommand command) => await _mediator.Send(command);

        [HttpGet("{locationName}/{officeName}")]
        public async Task<GetAllBookingsResponse> GetAllBookings([FromRoute] string locationName, string officeName) => await _mediator.Send(new GetAllBookingsQuery(locationName, officeName));
    }
}
