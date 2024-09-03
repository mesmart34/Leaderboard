using Leaderboard.Application.Entities.User.Commands;
using Leaderboard.Application.Entities.User.Queries;
using Leaderboard.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Leaderboard.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<TableUser>> GetUserById(Guid id)
    {
        var user = await mediator.Send(new GetUserByIdQuery()
        {
            Id = id
        });
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    
    [HttpGet]
    public async Task<ActionResult<TableUser>> GetAllUsers()
    {
        var user = await mediator.Send(new GetUsers());
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<TableUser>> AddUser([FromBody]SignUpCommand userCommand)
    {
        var user = await mediator.Send(new SignUpCommand()
        {
            FirstName = userCommand.FirstName,
            LastName = userCommand.LastName,
            Email = userCommand.Email,
            Password = userCommand.Password
        });
        return Ok(user);
    }
}