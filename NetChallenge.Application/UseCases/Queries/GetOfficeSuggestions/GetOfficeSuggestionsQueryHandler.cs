using AutoMapper;
using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions
{
    public class GetOfficeSuggestionsQueryHandler : IRequestHandler<GetOfficeSuggestionsQuery, IEnumerable<OfficeDto>>
    {
        private readonly IOfficeRentalService _service;
        private readonly IMapper _mapper;

        public GetOfficeSuggestionsQueryHandler(IOfficeRentalService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public Task<IEnumerable<OfficeDto>> Handle(GetOfficeSuggestionsQuery request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<SuggestionsRequest>(request);

            var officesSuggestions = _service.GetOfficeSuggestionsDb(dto);

            return Task.FromResult(officesSuggestions);
        }
    }
}
