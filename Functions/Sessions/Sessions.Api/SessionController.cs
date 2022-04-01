using Sessions.Core.Models.Commands;
using Sessions.Core.Models.Queries;
using Functions.Infrastructure.Features;
using Microsoft.AspNetCore.Mvc;

namespace Sessions.Api;

[Route("/")]
public class SessionController : ControllerBase
{
    private readonly IEventingService _eventingService;

    public SessionController(IEventingService eventingService)
    {
        _eventingService = eventingService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _eventingService.QueryAsync<SessionQueryResult>(new GetSessionsQuery(), EventTargets.SessionsDb);
        return Ok(result.Sessions);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSessionCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.SessionsDb);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSessionCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.SessionsDb);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _eventingService.SendCommandAsync(new DeleteSessionCommand { Id = id }, EventTargets.SessionsDb);
        return Ok();
    }
}