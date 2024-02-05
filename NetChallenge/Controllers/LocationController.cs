using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.UseCases.Commands.AddLocation;
using NetChallenge.Application.UseCases.Queries.GetAllLocations;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;

namespace NetChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ISender _mediator;

        public LocationController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<StandardResponse> AddLocation([FromBody] AddLocationCommand command) => await _mediator.Send(command);

        [HttpGet]
        public async Task<GetAllLocationsResponse> GetAllLocations() => await _mediator.Send(new GetAllLocationsQuery());
    }
}
