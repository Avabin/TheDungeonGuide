using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;


namespace Players.Mongo.CommandHandlers;

public class CreatePlayerCommandHandler : IEventHandler<CreatePlayerCommand>
{
    private readonly DataService _dataService;

    public CreatePlayerCommandHandler(DataService dataService) =>
        _dataService = dataService;

    public async Task Handle(CreatePlayerCommand @event) =>
        await _dataService.Create(@event);
}