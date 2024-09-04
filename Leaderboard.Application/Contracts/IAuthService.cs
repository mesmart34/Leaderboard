using Leaderboard.Application.Entities.Auth.Commands.AuthRegister;
using Leaderboard.Application.Entities.Auth.Queries.AuthLogin;

namespace Leaderboard.Application.Contracts;

public interface IAuthService
{
    public Task<AuthLoginResponse?> Login(AuthLoginQuery command);
    public Task<bool> Register(AuthRegisterCommand command);
}