using MediatR;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;

namespace NetChallenge.Application.UseCases.Queries.GetAllOffices
{
    public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, GetAllOfficesResponse>
    {
        private readonly IOfficeRentalService _service;

        public GetAllOfficesQueryHandler(IOfficeRentalService service)
        {
            _service = service;
        }

        public Task<GetAllOfficesResponse> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var offices = _service.GetOfficesDb(request.LocationName);

                return Task.FromResult(new GetAllOfficesResponse("Getting offices happened successfully.", offices));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GetAllOfficesResponse(ex.Message, new List<OfficeDto>()));
            }
        }
    }
}
