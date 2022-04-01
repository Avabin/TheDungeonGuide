using Functions.Infrastructure.Features.Events;

namespace Players.Core.Models.Commands;

public class UpdatePlayerCommand : PlayerBase, ICommand
{
    public string Id { get; set; } = "";
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
}