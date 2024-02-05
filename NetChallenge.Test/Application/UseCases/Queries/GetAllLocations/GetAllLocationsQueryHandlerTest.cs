using AutoFixture;
using FluentAssertions;
using Moq;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.UseCases.Queries.GetAllBookings;
using NetChallenge.Application.UseCases.Queries.GetAllLocations;
using NetChallenge.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
