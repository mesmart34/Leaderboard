using MediatR;

namespace Leaderboard.Application.Entities.Auth.Queries.AuthLogin;

public class AuthLoginQuery : IRequest<AuthLoginResponse?>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}