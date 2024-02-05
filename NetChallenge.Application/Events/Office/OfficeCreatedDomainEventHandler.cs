using MediatR;
using Microsoft.Extensions.Logging;
using NetChallenge.Domain.DomainEvents.Office;

namespace NetChallenge.Application.Events.Office
{
    public sealed class OfficeCreatedDomainEventHandler : INotificationHandler<OfficeCreatedDomainEvent>
    {
        private readonly ILogger<OfficeCreatedDomainEventHandler> _logger;

        public OfficeCreatedDomainEventHandler(ILogger<OfficeCreatedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(OfficeCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Office {name} was created.", notification.OfficeName);

            return Task.CompletedTask;
        }
    }
}
