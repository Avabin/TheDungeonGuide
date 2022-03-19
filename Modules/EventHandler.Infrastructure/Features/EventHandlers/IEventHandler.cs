using EventHandler.Infrastructure.Features.Events;

namespace EventHandler.Infrastructure.Features.EventHandlers;

public interface IEventHandler<in T> where T : IEvent

{
    Task Handle(T @event);
}