using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Entities;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, GetAllBookingsResponse>
    {
        private readonly IOfficeRentalService _service;

        public GetAllBookingsQueryHandler(IOfficeRentalService service)
        {
            _service = service;
        }

        public Task<GetAllBookingsResponse> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bookings = _service.GetBookingsDb(request.LocationName, request.OfficeName);

                return Task.FromResult(new GetAllBookingsResponse("Getting office's book happened successfully.", bookings));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GetAllBookingsResponse(ex.Message, new List<BookingDto>()));
            }
        }
    }
}
