using EventHandler.Infrastructure.Features.Events;

namespace Characters.Core.Models.Queries;

public class GetCharactersQuery : IQuery
{
    public Guid CorrelationId { get; set; } = Guid.NewGuid();
    public int? Skip          { get; set; }
    public int? Take          { get; set; }
}