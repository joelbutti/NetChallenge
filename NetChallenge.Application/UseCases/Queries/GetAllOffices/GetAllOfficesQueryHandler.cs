using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllOffices
{
    public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, IEnumerable<OfficeDto>>
    {
        private readonly IOfficeRentalService _service;

        public GetAllOfficesQueryHandler(IOfficeRentalService service)
        {
            _service = service;
        }

        public Task<IEnumerable<OfficeDto>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetOffices(request.LocationName));
        }
    }
}
