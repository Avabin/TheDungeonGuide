namespace Sessions.Core.Models.Queries;

public class SessionQueryResult
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public List<Session> Sessions { get; set; } = new();
}