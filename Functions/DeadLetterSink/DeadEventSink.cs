using EventHandler.Infrastructure.Features.EventHandlers;
using EventHandler.Infrastructure.Features.Events;

namespace DeadLetterSink;

public class DeadEventSink : IEventHandler<IEvent>
{
    private readonly ILogger<DeadEventSink> _logger;

    public DeadEventSink(ILogger<DeadEventSink> logger)
    {
        _logger = logger;
    }
    public Task Handle(IEvent @event)
    {
        _logger.LogWarning("Dead event: {@Event}", @event);
        return Task.CompletedTask;
    }
}