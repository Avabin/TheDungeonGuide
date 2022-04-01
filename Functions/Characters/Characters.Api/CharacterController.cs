using Characters.Core.Models.Commands;
using Characters.Core.Models.Queries;
using Functions.Infrastructure.Features;
using Microsoft.AspNetCore.Mvc;

namespace Characters.Api;

[Route("/")]
public class CharacterController : ControllerBase
{
    private readonly IEventingService _eventingService;

    public CharacterController(IEventingService eventingService)
    {
        _eventingService = eventingService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _eventingService.QueryAsync<CharacterQueryResult>(new GetCharactersQuery(), EventTargets.CharactersDb);
        return Ok(result.Characters);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCharacterCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.CharactersDb);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCharacterCommand command)
    {
        await _eventingService.SendCommandAsync(command, EventTargets.CharactersDb);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _eventingService.SendCommandAsync(new DeleteCharacterCommand { Id = id }, EventTargets.CharactersDb);
        return Ok();
    }
}