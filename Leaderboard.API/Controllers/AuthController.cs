using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Leaderboard.API.Authorization.Config;
using Leaderboard.Application.Entities.User.Commands;
using Leaderboard.Application.Entities.User.Queries;
using Leaderboard.Application.Entities.User.Response;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace Leaderboard.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[SwaggerControllerOrder(1)]
public class AuthController(LeaderboardDbContext dbContext, IConfiguration configuration, IMediator mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerOperation("Sign up")]
    public async Task<IActionResult> SignUp([FromQuery]SignUpCommand request)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user != null)
        {
            return Ok("User with the same email has already been registered!");
        }
    
        user = await mediator.Send(new SignUpCommand()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        });
    
        if (user == null)
        {
            throw new Exception("Couldn't add the entity to db");
        }
        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation("Sign In")]
    public async Task<ActionResult<AuthResponse>> SignIn([FromQuery]SingInQuery request)
    {
        var user = await mediator.Send(request);
    
        if (user == null)
        {
            return NotFound();
        }
            
        var jwtConfig = configuration.GetSection(JwtSettings.ConfigSection).Get<JwtSettings>();
        if (jwtConfig == null)
        {
            return BadRequest();
        }
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    
        var secToken = new JwtSecurityToken(jwtConfig.Issuer,
            jwtConfig.Issuer,
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);
    
        var token =  new JwtSecurityTokenHandler().WriteToken(secToken);
    
        return new AuthResponse()
        {
            Token = token
        };
    }
}