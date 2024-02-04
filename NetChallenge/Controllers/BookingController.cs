using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NetChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ISender _mediator;

        public BookingController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
