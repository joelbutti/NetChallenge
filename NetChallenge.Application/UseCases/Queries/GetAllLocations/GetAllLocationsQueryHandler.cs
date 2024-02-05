using AutoMapper;
using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.UseCases.Queries.GetAllBookings;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
