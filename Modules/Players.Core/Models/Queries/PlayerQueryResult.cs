using Functions.Infrastructure.Features.Events;

namespace Players.Core.Models.Queries;

public class PlayerQueryResult : IEvent
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    
    public IEnumerable<Player> Players { get; set; } = new List<Player>();
}