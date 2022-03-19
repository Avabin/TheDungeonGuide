namespace Sessions.Core.Models.Commands;

public class CreateSessionCommand : SessionBase
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}