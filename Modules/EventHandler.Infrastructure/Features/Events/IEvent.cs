﻿namespace EventHandler.Infrastructure.Features.Events;

public interface IEvent
{
    Guid CorrelationId { get; set; }
}

public interface IQuery : IEvent
{
    
}

public interface ICommand : IEvent
{
    
}

public abstract class EventBase : IEvent
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}

public abstract class QueryBase : EventBase, IQuery
{
    
}

public abstract class CommandBase : EventBase, ICommand
{
    
}

public class QueryInts : QueryBase
{
    public int Count { get; set; }
}

public class DoNothingCommand : CommandBase
{
    
}
