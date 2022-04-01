using Sessions.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Sessions.Mongo.CommandHandlers;

public class CreateSessionCommandHandler : IEventHandler<CreateSessionCommand>
{
    private readonly DataService _dataService;

    public CreateSessionCommandHandler(DataService dataService) => 
        _dataService = dataService;

    public async Task Handle(CreateSessionCommand @event) => 
        await _dataService.Create(@event);
}