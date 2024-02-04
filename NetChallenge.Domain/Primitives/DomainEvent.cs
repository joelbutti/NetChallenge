using MediatR;

namespace NetChallenge.Domain.Primitives;

public record DomainEvent(Guid Id) : INotification;