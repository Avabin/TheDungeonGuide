using EventHandler.Infrastructure.Features.Events;

namespace Characters.Core.Models.Queries;

public class CharacterQueryResult : IEvent
{
    public Guid            CorrelationId { get; set; } = Guid.NewGuid();
    public List<Character> Characters    { get; set; } = new();
}