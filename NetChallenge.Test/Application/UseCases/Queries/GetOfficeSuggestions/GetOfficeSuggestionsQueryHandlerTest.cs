using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.UseCases.Queries.GetAllOffices;
using NetChallenge.Application.UseCases.Queries.GetOfficeSuggestions;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Queries.GetOfficeSuggestions
{
    public class GetOfficeSuggestionsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_GetOfficeSuggestions_NotEmpty()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var mapper = new Mock<IMapper>();
            var handler = new GetOfficeSuggestionsQueryHandler(service.Object, mapper.Object);
            var request = new Fixture().Create<GetOfficeSuggestionsQuery>();

            mapper.Setup(x => x.Map<SuggestionsRequest>(It.IsAny<GetOfficeSuggestionsQuery>())).Returns(new SuggestionsRequest());
            service.Setup(x => x.GetOfficeSuggestionsDb(It.IsAny<SuggestionsRequest>())).Returns(new List<OfficeDto>() { new OfficeDto() });

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Offices.Should().NotBeEmpty();
        }
    }
}
