using AutoMapper;
using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                return new StandardResponse("Location was created succesfully.", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {

                return new StandardResponse(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}

