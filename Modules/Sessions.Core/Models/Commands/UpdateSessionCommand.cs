using Functions.Infrastructure.Features.Events;

namespace Sessions.Core.Models.Commands;

public class UpdateSessionCommand : SessionBase, ICommand
{
    public string Id            { get; set; } = "";
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
}