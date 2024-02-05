using AutoMapper;
using MediatR;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Application.UseCases.Commands.AddLocation
{
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, StandardResponse>
    {
        private readonly IOfficeRentalService _service;
        private readonly IMapper _mapper;

        public AddLocationCommandHandler(IOfficeRentalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<StandardResponse> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<AddLocationRequest>(request);

                await _service.AddLocationDb(dto);

                return new StandardResponse($"Location {request.Name} was created succesfully.", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {

                return new StandardResponse(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}

