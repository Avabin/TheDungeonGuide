using Functions.Infrastructure.Features.Events;

namespace Sessions.Core.Models.Queries;

public class SessionQueryResult : IEvent
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public List<Session> Sessions { get; set; } = new();
}