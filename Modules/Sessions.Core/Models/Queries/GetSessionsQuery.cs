using Functions.Infrastructure.Features.Events;

namespace Sessions.Core.Models.Queries;

public class GetSessionsQuery : IQuery
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public int? Skip          { get; set; }
    public int? Take          { get; set; }
}