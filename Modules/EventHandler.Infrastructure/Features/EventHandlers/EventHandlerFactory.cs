using EventHandler.Infrastructure.Features.Events;

namespace EventHandler.Infrastructure.Features.EventHandlers;

internal class EventHandlerFactory : IEventHandlerFactory
{
    private readonly IServiceProvider _provider;

    public EventHandlerFactory(IServiceProvider provider)
    {
        _provider = provider;
    }
    public IEventHandler<T> Create<T>() where T : IEvent => 
        _provider.GetRequiredService<IEventHandler<T>>();
}