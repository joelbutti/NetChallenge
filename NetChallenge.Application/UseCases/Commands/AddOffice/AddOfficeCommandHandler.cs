using AutoMapper;
using MediatR;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Application.UseCases.Commands.AddOffice
{
    public class AddOfficeCommandHandler : IRequestHandler<AddOfficeCommand, StandardResponse>
    {
        private readonly IOfficeRentalService _service;
        private readonly IMapper _mapper;

        public AddOfficeCommandHandler(IOfficeRentalService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<StandardResponse> Handle(AddOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<AddOfficeRequest>(request);

                await _service.AddOfficeDb(dto);

                return new StandardResponse($"Office {request.Name} in location {request.LocationName} was created succesfully.", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new StandardResponse(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
