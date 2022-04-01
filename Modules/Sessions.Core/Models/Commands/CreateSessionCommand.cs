using Functions.Infrastructure.Features.Events;

namespace Sessions.Core.Models.Commands;

public class CreateSessionCommand : SessionBase, ICommand
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}