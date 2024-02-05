using AutoMapper;
using MediatR;
using NetChallenge.Application.Abstractions;
using NetChallenge.Domain.Dtos;
using NetChallenge.Dtos.Input;

namespace NetChallenge.Application.UseCases.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, StandardResponse>
    {
        private readonly IOfficeRentalService _service;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IOfficeRentalService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<StandardResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = _mapper.Map<BookOfficeRequest>(request);
                dto.Duration = TimeSpan.FromMinutes(request.DurationInMinutes);

                await _service.BookOfficeDb(dto);

                return new StandardResponse($"Office {request.OfficeName} was booked succesfully.", System.Net.HttpStatusCode.Created);
            }
            catch (Exception ex)
            {

                return new StandardResponse(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }

        }
    }
}
