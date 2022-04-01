using Sessions.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Sessions.Mongo.CommandHandlers;

public class DeleteSessionCommandHandler : IEventHandler<DeleteSessionCommand>
{
    private readonly DataService _dataService;

    public DeleteSessionCommandHandler(DataService dataService) => 
        _dataService = dataService;

    public async Task Handle(DeleteSessionCommand @event) => 
        await _dataService.Delete(@event.Id);
}