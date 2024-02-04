using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.UseCases.Commands.AddLocation;
using NetChallenge.Application.UseCases.Commands.AddOffice;
using NetChallenge.Application.UseCases.Queries.GetAllLocations;
using NetChallenge.Application.UseCases.Queries.GetAllOffices;
using NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dto.Output;

namespace NetChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly ISender _mediator;

        public OfficeController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<StandardResponse> AddOffice([FromBody] AddOfficeCommand command) => await _mediator.Send(command);

        [HttpGet("{locationName}")]
        public async Task<IEnumerable<OfficeDto>> GetAllOffices([FromRoute] string locationName) => await _mediator.Send(new GetAllOfficesQuery(locationName));

        [HttpPost("Suggestions")]
        public async Task<IEnumerable<OfficeDto>> GetOfficeSuggestions([FromBody] GetOfficeSuggestionsQuery command) => await _mediator.Send(command);
    }
}
