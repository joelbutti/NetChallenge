using MediatR;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;

namespace NetChallenge.Application.UseCases.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, GetAllLocationsResponse>
    {
        private readonly IOfficeRentalService _service;

        public GetAllLocationsQueryHandler(IOfficeRentalService service)
        {
            _service = service;
        }

        public Task<GetAllLocationsResponse> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var locations = _service.GetLocationsDb();

                return Task.FromResult(new GetAllLocationsResponse("Getting locations happened successfully.", locations));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GetAllLocationsResponse(ex.Message, new List<LocationDto>()));
            }
        }
    }

}
