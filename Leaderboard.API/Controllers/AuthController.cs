using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Leaderboard.API.Authorization.Config;
using Leaderboard.Application.Contracts;
using Leaderboard.Application.Entities.Auth.Commands.AuthRegister;
using Leaderboard.Application.Entities.Auth.Queries;
using Leaderboard.Application.Entities.Auth.Queries.AuthLogin;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace Leaderboard.API.Controllers;

[Route("auth")]
[ApiController]
[SwaggerControllerOrder(1)]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    [AllowAnonymous]
    [SwaggerOperation("Register")]
    public async Task<IActionResult> Register([FromBody]AuthRegisterCommand command)
    {
        var registered = await authService.Register(command);
        if (registered)
        {
            return Problem("User already exists");
        }

        return Ok();
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    [SwaggerOperation("Login")]
    public async Task<ActionResult<AuthLoginResponse>> Login([FromBody]AuthLoginQuery command)
    {
        var response = await authService.Login(command);
        if (response == null)
        {
            return NotFound("User not found");
        }
        return response;
    }
}