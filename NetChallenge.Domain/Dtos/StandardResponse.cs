using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Domain.Dtos
{
    public record struct StandardResponse(string Message, HttpStatusCode StatusCode);
}
