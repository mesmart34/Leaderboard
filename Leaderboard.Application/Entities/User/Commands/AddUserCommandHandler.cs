using System.Text.Json;
using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Leaderboard.Application.Entities.User.Commands;

public class AddUserCommandHandler(LeaderboardDbContext dbContext, IDistributedCache distributedCache) : IRequestHandler<AddUserCommand, TableUser?>
{
    public async Task<TableUser?> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new TableUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            IsAdmin = request.IsAdmin
        };
        user = (await dbContext.Users.AddAsync(user, cancellationToken)).Entity;
        var bytes = JsonSerializer.SerializeToUtf8Bytes(user);
        await distributedCache.SetAsync($"user-{user.Id}", bytes, token: cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return user;
    }
}
