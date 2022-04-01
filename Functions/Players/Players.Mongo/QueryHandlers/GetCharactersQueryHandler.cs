using Players.Core.Models.Queries;
using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.EventHandlers;


namespace Players.Mongo.QueryHandlers;

public class GetPlayersQueryHandler : IEventHandler<GetPlayersQuery>
{
    private readonly IEventingService                                                                           _eventingService;
    private readonly DataService _dataService;

    public GetPlayersQueryHandler(IEventingService eventingService, DataService dataService)
    {
        _eventingService = eventingService;
        _dataService     = dataService;
    }

    public async Task Handle(GetPlayersQuery @event)
    {
        var players = await _dataService.ReadAll(@event.Skip, @event.Take);

        var response = new PlayerQueryResult
        {
            CorrelationId = @event.CorrelationId,
            Players    = players.ToList()
        };
        
        await _eventingService.PublishEventAsync(response, EventTargets.PlayersApi);
    }
}