using EventHandler.Infrastructure.Features.Events;

namespace EventHandler.Infrastructure.Features.EventHandlers;

public interface IEventHandlerFactory
{
    IEventHandler<T> Create<T>() where T : IEvent;
}