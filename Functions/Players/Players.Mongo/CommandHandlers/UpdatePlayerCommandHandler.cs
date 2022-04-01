using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Players.Mongo.CommandHandlers;

public class UpdatePlayerCommandHandler : IEventHandler<UpdatePlayerCommand>
{
    private readonly DataService _dataService;

    public UpdatePlayerCommandHandler(DataService dataService)
    {
        _dataService = dataService;
    }
    public async Task Handle(UpdatePlayerCommand @event) => 
        await _dataService.Update(@event.Id, @event);
}