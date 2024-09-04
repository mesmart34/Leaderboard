using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Leaderboard.API.Authorization.Config;
using Leaderboard.Application.Contracts;
using Leaderboard.Application.Entities.Auth.Commands.AuthRegister;
using Leaderboard.Application.Entities.Auth.Queries.AuthLogin;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Leaderboard.API.Services;

public class AuthService(IMediator mediator, LeaderboardDbContext dbContext, IConfiguration configuration)
    : IAuthService
{
    public async Task<AuthLoginResponse?> Login(AuthLoginQuery command)
    {
        var user = await mediator.Send(command);

        if (user == null)
        {
            return null;
        }

        var jwtConfig = configuration.GetSection(JwtSettings.ConfigSection).Get<JwtSettings>();
        if (jwtConfig == null)
        {
            return null;
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var secToken = new JwtSecurityToken(jwtConfig.Issuer,
            jwtConfig.Issuer,
            null,
            expires: DateTime.Now.AddMonths(1),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(secToken);

        return new AuthLoginResponse()
        {
            Token = token
        };
    }

    public async Task<bool> Register(AuthRegisterCommand command)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == command.Email);
        if (user != null)
        {
            return false;
        }

        user = await mediator.Send(new AuthRegisterCommand()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        });

        if (user == null)
        {
            throw new Exception("Couldn't add the entity to db");
        }

        return true;
    }
}