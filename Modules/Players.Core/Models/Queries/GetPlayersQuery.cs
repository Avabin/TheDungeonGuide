using Functions.Infrastructure.Features.Events;

namespace Players.Core.Models.Queries;

public class GetPlayersQuery : IQuery
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();

    public int? Skip { get; set; }
    public int? Take { get; set; }
}