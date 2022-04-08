using Functions.Infrastructure.Features.Events;

namespace Players.Core.Models.Queries;

public class GetPlayerQuery : IQuery
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();

    public string PlayerName { get; set; } = "";
        
    public string ApiKey { get; set; } = "";
    
}