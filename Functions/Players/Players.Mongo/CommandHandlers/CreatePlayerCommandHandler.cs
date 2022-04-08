using Players.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;
using Players.Mongo.Core.Services;


namespace Players.Mongo.CommandHandlers;

public class CreatePlayerCommandHandler : IEventHandler<CreatePlayerCommand>
{
    private readonly IPlayersDataService _dataService;

    public CreatePlayerCommandHandler(IPlayersDataService dataService) =>
        _dataService = dataService;

    public async Task Handle(CreatePlayerCommand @event) =>
        await _dataService.InsertAsync(@event);
}