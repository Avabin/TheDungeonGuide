using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;
using Players.Mongo.Core.Services;

namespace Players.Mongo.CommandHandlers;

public class UpdatePlayerCommandHandler : IEventHandler<UpdatePlayerCommand>
{
    private readonly IPlayersDataService _dataService;

    public UpdatePlayerCommandHandler(IPlayersDataService dataService)
    {
        _dataService = dataService;
    }
    public async Task Handle(UpdatePlayerCommand @event) => 
        await _dataService.UpdateAsync(@event.Id, @event);
}