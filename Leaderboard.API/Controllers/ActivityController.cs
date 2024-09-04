using Leaderboard.Application.Entities.Activity.Commands;
using Leaderboard.Application.Entities.Activity.Commands.AddActivity;
using Leaderboard.Application.Entities.Activity.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace Leaderboard.API.Controllers;

[Authorize]
[Route("activity")]
[ApiController]
[SwaggerControllerOrder(2)]
public class ActivityController(IMediator mediator) : ControllerBase
{
    [SwaggerOperation("Add an activity")]
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddActivityCommand command)
    {
        var activity = await mediator.Send(command);
        return Ok(activity);
    }

    [SwaggerOperation("Get all activities")]
    [HttpGet("get")]
    public async Task<IActionResult> Get(GetActivitiesQuery query)
    {
        var activities = await mediator.Send(query);
        return Ok(activities);
    }
    
    [SwaggerOperation("Get an activity by id")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(GetActivityByIdQuery query)
    {
        var activities = await mediator.Send(query);
        return Ok(activities);
    }
}