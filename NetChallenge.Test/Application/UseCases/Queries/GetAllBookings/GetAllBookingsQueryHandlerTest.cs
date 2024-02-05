using AutoFixture;
using FluentAssertions;
using Moq;
using NetChallenge.Application.UseCases.Queries.GetAllBookings;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dto.Output;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandlerTest
    {
        [Fact]
        public async Task Handle_GetAllBookings_NotEmpty()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var handler = new GetAllBookingsQueryHandler(service.Object);
            var request = new Fixture().Create<GetAllBookingsQuery>();

            service.Setup(x => x.GetBookingsDb(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<BookingDto>() { new BookingDto()});

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Bookings.Should().NotBeEmpty();
        }
    }
}
