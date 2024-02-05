using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.UseCases.Commands.AddOffice;
using NetChallenge.Application.UseCases.Queries.GetAllBookings;
using NetChallenge.Dto.Output;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
