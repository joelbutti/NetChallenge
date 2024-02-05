using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.UseCases.Commands.AddBook;
using NetChallenge.Dtos.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NetChallenge.Test.Application.UseCases.Commands.AddBook
{
    public class AddBookCommandHandlerTest
    {
        [Fact]
        public async Task Handle_AddBook_Ok()
        {
            //Arrange
            var service = new Mock<IOfficeRentalService>();
            var mapper = new Mock<IMapper>();
            var handler = new AddBookCommandHandler(service.Object, mapper.Object);
            var request = new Fixture().Create<AddBookCommand>();

            mapper.Setup(x => x.Map<BookOfficeRequest>(It.IsAny<AddBookCommand>())).Returns(new BookOfficeRequest());
            service.Setup(x => x.BookOfficeDb(It.IsAny<BookOfficeRequest>()));

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }
    }
}
