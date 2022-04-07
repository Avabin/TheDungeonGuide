using Functions.Infrastructure.Features.Events;

namespace Sessions.Core.Models.Commands;

public class DeleteSessionCommand : ICommand
{
    public string Id            { get; set; } = "";
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
    public string ApiKey        { get; set; } = "";
}