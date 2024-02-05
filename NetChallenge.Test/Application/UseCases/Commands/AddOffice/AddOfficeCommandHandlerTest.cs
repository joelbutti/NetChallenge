using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NetChallenge.Application.UseCases.Commands.AddOffice;
using NetChallenge.Domain.Abstractions;
using NetChallenge.Dtos.Input;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Commands.AddOffice
{
    public class AddOfficeCommandHandlerTest
    {
        [Fact]
        public async Task Handle_AddOffice_Ok()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var mapper = new Mock<IMapper>();
            var handler = new AddOfficeCommandHandler(service.Object, mapper.Object);
            var request = new Fixture().Create<AddOfficeCommand>();

            mapper.Setup(x => x.Map<AddOfficeRequest>(It.IsAny<AddOfficeCommand>())).Returns(new AddOfficeRequest());
            service.Setup(x => x.AddOfficeDb(It.IsAny<AddOfficeRequest>()));

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }
    }
}
