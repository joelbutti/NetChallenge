using MediatR;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllBookings
{
    public record struct GetAllBookingsQuery(string LocationName, string OfficeName) : IRequest<GetAllBookingsResponse>;
}
