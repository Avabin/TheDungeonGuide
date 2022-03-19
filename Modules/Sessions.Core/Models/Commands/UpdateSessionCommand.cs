namespace Sessions.Core.Models.Commands;

public class UpdateSessionCommand : SessionBase
{
    public string Id            { get; set; } = "";
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
}