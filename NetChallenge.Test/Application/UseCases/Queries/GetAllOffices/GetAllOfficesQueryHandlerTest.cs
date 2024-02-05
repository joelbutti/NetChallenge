using AutoFixture;
using FluentAssertions;
using Moq;
using NetChallenge.Application.UseCases.Queries.GetAllOffices;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Queries.GetAllOffices
{
    public class GetAllOfficesQueryHandlerTest
    {
        [Fact]
        public async Task Handle_GetAllOffices_NotEmpty()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var handler = new GetAllOfficesQueryHandler(service.Object);
            var request = new Fixture().Create<GetAllOfficesQuery>();

            service.Setup(x => x.GetOfficesDb(It.IsAny<string>())).Returns(new List<OfficeDto>() { new OfficeDto() });

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Offices.Should().NotBeEmpty();
        }
    }
}
