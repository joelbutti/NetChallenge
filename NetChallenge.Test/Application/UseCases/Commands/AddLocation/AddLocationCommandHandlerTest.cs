using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NetChallenge.Application.UseCases.Commands.AddLocation;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dtos.Input;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Commands.AddLocation
{
    public class AddLocationCommandHandlerTest
    {
        [Fact]
        public async Task Handle_AddLocation_Ok()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var mapper = new Mock<IMapper>();
            var handler = new AddLocationCommandHandler(service.Object, mapper.Object);
            var request = new Fixture().Create<AddLocationCommand>();

            mapper.Setup(x => x.Map<AddLocationRequest>(It.IsAny<AddLocationCommand>())).Returns(new AddLocationRequest());
            service.Setup(x => x.AddLocationDb(It.IsAny<AddLocationRequest>()));

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }
    }
}
