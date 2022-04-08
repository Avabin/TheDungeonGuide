using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;
using Players.Mongo.Core.Services;

namespace Players.Mongo.CommandHandlers;

public class DeletePlayerCommandHandler : IEventHandler<DeletePlayerCommand>
{
    private readonly IPlayersDataService _dataService;

    public DeletePlayerCommandHandler(IPlayersDataService dataService) => 
        _dataService = dataService;

    public async Task Handle(DeletePlayerCommand @event) => 
        await _dataService.DeleteAsync(@event.Id);
}