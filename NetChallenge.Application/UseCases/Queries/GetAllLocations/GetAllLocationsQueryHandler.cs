using AutoMapper;
using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IEnumerable<LocationDto>>
    {
        private readonly IOfficeRentalService _service;

        public GetAllLocationsQueryHandler(IOfficeRentalService service)
        {
            _service = service;
        }

        public Task<IEnumerable<LocationDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GetLocations());
        }
    }

}
