using Sessions.Core.Models.Queries;
using Functions.Infrastructure.Features;
using Functions.Infrastructure.Features.EventHandlers;


namespace Sessions.Mongo.QueryHandlers;

public class GetSessionsQueryHandler : IEventHandler<GetSessionsQuery>
{
    private readonly IEventingService                                                                           _eventingService;
    private readonly DataService _dataService;

    public GetSessionsQueryHandler(IEventingService eventingService, DataService dataService)
    {
        _eventingService = eventingService;
        _dataService     = dataService;
    }

    public async Task Handle(GetSessionsQuery @event)
    {
        var chars = await _dataService.ReadAll(@event.Skip, @event.Take);

        var response = new SessionQueryResult
        {
            CorrelationId = @event.CorrelationId,
            Sessions    = chars.ToList()
        };
        
        await _eventingService.PublishEventAsync(response, EventTargets.SessionsApi);
    }
}