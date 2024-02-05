using MediatR;
using Microsoft.Extensions.Logging;
using NetChallenge.Domain.DomainEvents.Booking;

namespace NetChallenge.Application.Events.Booking
{
    public sealed class BookingCreatedDomainEventHandler : INotificationHandler<BookingCreatedDomainEvent>
    {
        private readonly ILogger<BookingCreatedDomainEventHandler> _logger;

        public BookingCreatedDomainEventHandler(ILogger<BookingCreatedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BookingCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("User {user} was booked an office on {date} for {hours} hours and {minutes} minutes.", 
                notification.UserName, notification.Date, notification.Duration.Hours, notification.Duration.Minutes);

            return Task.CompletedTask;
        }
    }
}
