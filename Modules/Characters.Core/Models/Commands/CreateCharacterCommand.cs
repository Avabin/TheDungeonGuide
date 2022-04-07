using Functions.Infrastructure.Features.Events;

namespace Characters.Core.Models.Commands;

public class CreateCharacterCommand : CharacterBase, ICommand
{
    public Guid   CorrelationId { get; set; } = Guid.NewGuid();
    public string ApiKey        { get; set; } = "";
}