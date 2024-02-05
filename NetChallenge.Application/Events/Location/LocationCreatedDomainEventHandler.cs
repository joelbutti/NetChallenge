using MediatR;
using Microsoft.Extensions.Logging;
using NetChallenge.Domain.DomainEvents.Location;

namespace NetChallenge.Application.Events.Location
{
    public sealed class LocationCreatedDomainEventHandler : INotificationHandler<LocationCreatedDomainEvent>
    {
        private readonly ILogger<LocationCreatedDomainEventHandler> _logger;

        public LocationCreatedDomainEventHandler(ILogger<LocationCreatedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(LocationCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Location {name} was created.", notification.LocationName);

            return Task.CompletedTask;
        }
    }
}
