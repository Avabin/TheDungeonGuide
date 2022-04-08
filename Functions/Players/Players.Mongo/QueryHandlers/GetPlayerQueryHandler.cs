using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.EventHandlers;
using Players.Core.Models;
using Players.Core.Models.Queries;
using Players.Mongo.Core.Services;

namespace Players.Mongo.QueryHandlers;

public class GetPlayerQueryHandler : IEventHandler<GetPlayerQuery>
{
    private readonly IPlayersDataService _dataService;
    private readonly IEventingService    _eventingService;

    public GetPlayerQueryHandler(IPlayersDataService dataService, IEventingService eventingService)
    {
        _dataService          = dataService;
        _eventingService = eventingService;
    }
    public async Task Handle(GetPlayerQuery @event)
    {
        var player = await _dataService.FindByNameAsync(@event.PlayerName);

        var response = new PlayerQueryResult
        {
            Players = player is null ? Enumerable.Empty<Player>() : new[] { player }
        };

        await _eventingService.PublishEventAsync(response, EventTargets.PlayersApi);
    }
}