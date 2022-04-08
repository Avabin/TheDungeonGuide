using Sessions.Core.Models.Commands;
using Functions.Infrastructure.Features.EventHandlers;

namespace Sessions.Mongo.CommandHandlers;

public class UpdateSessionCommandHandler : IEventHandler<UpdateSessionCommand>
{
    private readonly DataService _dataService;

    public UpdateSessionCommandHandler(DataService dataService)
    {
        _dataService = dataService;
    }
    public async Task Handle(UpdateSessionCommand @event) => 
        await _dataService.UpdateAsync(@event.Id, @event);
}