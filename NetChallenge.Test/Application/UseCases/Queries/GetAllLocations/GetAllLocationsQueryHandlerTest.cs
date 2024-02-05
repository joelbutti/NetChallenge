using AutoFixture;
using FluentAssertions;
using Moq;
using NetChallenge.Application.UseCases.Queries.GetAllLocations;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Queries.GetAllLocations
{
    public class GetAllLocationsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_GetAllLocations_NotEmpty()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var handler = new GetAllLocationsQueryHandler(service.Object);
            var request = new Fixture().Create<GetAllLocationsQuery>();

            service.Setup(x => x.GetLocationsDb()).Returns(new List<LocationDto>() { new LocationDto() });

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Locations.Should().NotBeEmpty();
        }
    }
}
