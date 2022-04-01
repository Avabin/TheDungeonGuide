using Functions.Infrastructure.Features.Events;

namespace Players.Core.Models.Commands;

public class CreatePlayerCommand : PlayerBase, ICommand
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}