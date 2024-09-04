using System.Text.Json;
using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Leaderboard.Application.Entities.Auth.Commands.AuthRegister;

public class AuthRegisterCommandHandler(LeaderboardDbContext dbContext, IDistributedCache distributedCache) : IRequestHandler<AuthRegisterCommand, TableUser?>
{
    public async Task<TableUser?> Handle(AuthRegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new TableUser
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };
        user = (await dbContext.Users.AddAsync(user, cancellationToken)).Entity;
        var bytes = JsonSerializer.SerializeToUtf8Bytes(user);
        await distributedCache.SetAsync($"user-{user.Id}", bytes, token: cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }
}
