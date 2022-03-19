using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using EventHandler.Infrastructure.Features.EventHandlers;

namespace EventHandler.Infrastructure.Features.Events;

public class EventDispatcherHostedService<T> : IHostedService where T : IEvent
{
    private readonly IEventBus            _eventBus;
    private readonly IEventHandlerFactory _handlerFactory;
    private          IDisposable?         _sub;

    public EventDispatcherHostedService(IEventBus eventBus, IEventHandlerFactory handlerFactory)
    {
        _eventBus  = eventBus;
        _handlerFactory = handlerFactory;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _sub = _eventBus
              .OfType<T>()
              .Select(x => 
                          _handlerFactory
                             .Create<T>()
                             .Handle(x)
                             .ToObservable())
              .Concat()
              .Subscribe();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken  cancellationToken)
    {
        _sub?.Dispose();
        return Task.CompletedTask;
    }
}