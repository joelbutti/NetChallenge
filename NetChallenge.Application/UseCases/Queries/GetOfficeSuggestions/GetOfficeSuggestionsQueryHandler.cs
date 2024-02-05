using AutoMapper;
using MediatR;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions
{
    public class GetOfficeSuggestionsQueryHandler : IRequestHandler<GetOfficeSuggestionsQuery, GetOfficeSuggestionsResponse>
    {
        private readonly IOfficeRentalService _service;
        private readonly IMapper _mapper;

        public GetOfficeSuggestionsQueryHandler(IOfficeRentalService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public Task<GetOfficeSuggestionsResponse> Handle(GetOfficeSuggestionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<SuggestionsRequest>(request);

                var officesSuggestions = _service.GetOfficeSuggestionsDb(dto);

                return Task.FromResult(new GetOfficeSuggestionsResponse("Getting suggestions happened successfully.", officesSuggestions));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GetOfficeSuggestionsResponse(ex.Message, new List<OfficeDto>()));
            }
        }
    }
}
