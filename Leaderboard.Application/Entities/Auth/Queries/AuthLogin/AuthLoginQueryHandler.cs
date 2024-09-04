using Leaderboard.Application.Contracts;
using MediatR;

namespace Leaderboard.Application.Entities.Auth.Queries.AuthLogin;

public class AuthLoginQueryHandler(IAuthService authService) 
    : IRequestHandler<AuthLoginQuery, AuthLoginResponse?>
{
    public async Task<AuthLoginResponse?> Handle(AuthLoginQuery request, CancellationToken cancellationToken)
    {
        return await authService.Login(request);
    }
}