using Leaderboard.Application.Entities.Score.AddScoreCommand;
using Leaderboard.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace Leaderboard.API.Controllers;

[Authorize]
[Route("score")]
[ApiController]
[SwaggerControllerOrder(3)]
public class ScoreController(IMediator mediator) : Controller
{
    [SwaggerOperation("Add an activity")]
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddScoreCommand command)
    {
        var activity = await mediator.Send(command);
        return Ok(activity);
    }
}