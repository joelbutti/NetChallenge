using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.UseCases.Queries.GetAllOffices
{
    public record struct GetAllOfficesResponse(string Message, IEnumerable<OfficeDto> Offices);
}
