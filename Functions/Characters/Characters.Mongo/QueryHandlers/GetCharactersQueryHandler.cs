using Characters.Core.Models.Queries;
using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.EventHandlers;


namespace Characters.Mongo.QueryHandlers;

public class GetCharactersQueryHandler : IEventHandler<GetCharactersQuery>
{
    private readonly IEventingService                                                                           _eventingService;
    private readonly DataService _dataService;

    public GetCharactersQueryHandler(IEventingService eventingService, DataService dataService)
    {
        _eventingService = eventingService;
        _dataService     = dataService;
    }

    public async Task Handle(GetCharactersQuery @event)
    {
        var chars = await _dataService.FindAllAsync(@event.Skip, @event.Take);

        var response = new CharacterQueryResult
        {
            CorrelationId = @event.CorrelationId,
            Characters    = chars.ToList()
        };
        
        await _eventingService.PublishEventAsync(response, EventTargets.CharactersApi);
    }
}