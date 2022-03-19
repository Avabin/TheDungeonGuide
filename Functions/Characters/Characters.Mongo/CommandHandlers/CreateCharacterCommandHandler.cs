using Characters.Core.Models.Commands;
using EventHandler.Infrastructure.Features.EventHandlers;

namespace Characters.Mongo.CommandHandlers;

public class CreateCharacterCommandHandler : IEventHandler<CreateCharacterCommand>
{
    private readonly DataService _dataService;

    public CreateCharacterCommandHandler(DataService dataService) => 
        _dataService = dataService;

    public async Task Handle(CreateCharacterCommand @event) => 
        await _dataService.Create(@event);
}