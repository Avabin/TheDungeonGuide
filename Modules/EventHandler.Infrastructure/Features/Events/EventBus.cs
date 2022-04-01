﻿using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace EventHandler.Infrastructure.Features.Events;

public class EventBus : IEventBus, IDisposable
{
    private          IDisposable       _sub;
    private readonly ILogger<EventBus> _logger;
    private readonly ISubject<IEvent>  _eventStream = new Subject<IEvent>();

    public EventBus(ILogger<EventBus> logger)
    {
        _logger = logger;

        _sub = _eventStream.Do(x =>
        {
            _logger.LogInformation("Received event {EventType} ({EventId})", x.GetType().Name, x.CorrelationId);
            _logger.LogTrace("Received Event {@Event}", x);
        }).Subscribe();
    }

    public void Publish(IEvent @event)
    {
        _eventStream.OnNext(@event);
    }
    
    public IObservable<T> OfType<T>() where T : IEvent => 
        _eventStream.Distinct(x => x.CorrelationId)
                    .ObserveOn(TaskPoolScheduler.Default)
                    .SubscribeOn(TaskPoolScheduler.Default)
                    .OfType<T>();

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _sub.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}