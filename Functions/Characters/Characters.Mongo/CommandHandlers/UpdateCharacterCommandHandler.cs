using Characters.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Characters.Mongo.CommandHandlers;

public class UpdateCharacterCommandHandler : IEventHandler<UpdateCharacterCommand>
{
    private readonly DataService _dataService;

    public UpdateCharacterCommandHandler(DataService dataService)
    {
        _dataService = dataService;
    }
    public async Task Handle(UpdateCharacterCommand @event) => 
        await _dataService.Update(@event.Id, @event);
}