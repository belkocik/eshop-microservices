using MediatR;

namespace Ordering.Domain.Abstractions;

public interface IDomainEvent : INotification
{
  Guid EventId => Guid.NewGuid();
  public DateTime OccuredOn => DateTime.Now;
  string EventType => GetType().AssemblyQualifiedName ?? "UnknownEventType";
}