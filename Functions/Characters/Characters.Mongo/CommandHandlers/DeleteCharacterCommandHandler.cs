using Characters.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Characters.Mongo.CommandHandlers;

public class DeleteCharacterCommandHandler : IEventHandler<DeleteCharacterCommand>
{
    private readonly DataService _dataService;

    public DeleteCharacterCommandHandler(DataService dataService) => 
        _dataService = dataService;

    public async Task Handle(DeleteCharacterCommand @event) => 
        await _dataService.Delete(@event.Id);
}