namespace Sessions.Core.Models.Commands;

public class DeleteSessionCommand
{
    public string Id            { get; set; } = "";
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
}