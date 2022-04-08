using Functions.Infrastructure.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Players.Core.Models.Commands;
using Players.Core.Models.Queries;

namespace Players.Api;
[Authorize(Roles = "gm")]
[Route("/")]
public class PlayerController : ControllerBase
{
    private readonly IEventingService _eventingService;

    public PlayerController(IEventingService eventingService)
    {
        _eventingService = eventingService;
    }
    
    [Authorize(Roles = "player")]
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var username = User.Identity.Name;
        if (!string.IsNullOrEmpty(username)) return NotFound(new { message = "User not found" });
        
        var result = await _eventingService.QueryAsync<PlayerQueryResult>(new GetPlayerQuery(), EventTargets.PlayersDb);
        var player = result.Players.SingleOrDefault();

        
        if (player == null) return NotFound(new { message = "Player not found" });

        return Ok(player);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _eventingService.QueryAsync<PlayerQueryResult>(new GetPlayersQuery(), EventTargets.PlayersDb);
        return Ok(result.Players);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePlayerCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.PlayersDb);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdatePlayerCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.PlayersDb);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _eventingService.SendCommandAsync(new DeletePlayerCommand { Id = id }, EventTargets.PlayersDb);
        return Ok();
    }
}