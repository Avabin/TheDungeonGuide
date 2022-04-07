using Functions.Infrastructure.Features.Events;

namespace Characters.Core.Models.Commands;

public class DeleteCharacterCommand : ICommand
{
    public string Id            { get; set; } = "";
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
    public string ApiKey        { get; set; } = "";
}