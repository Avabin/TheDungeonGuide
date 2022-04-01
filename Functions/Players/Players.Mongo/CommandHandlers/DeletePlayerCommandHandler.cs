using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Players.Mongo.CommandHandlers;

public class DeletePlayerCommandHandler : IEventHandler<DeletePlayerCommand>
{
    private readonly DataService _dataService;

    public DeletePlayerCommandHandler(DataService dataService) => 
        _dataService = dataService;

    public async Task Handle(DeletePlayerCommand @event) => 
        await _dataService.Delete(@event.Id);
}