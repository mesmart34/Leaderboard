using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard.Application.Entities.User.Queries;

public class GetUsersHandler(LeaderboardDbContext dbContext) : IRequestHandler<GetUsers, List<TableUser>>
{
    public async Task<List<TableUser>> Handle(GetUsers request, CancellationToken cancellationToken)
    {
        var users = await dbContext.Users.ToListAsync(cancellationToken: cancellationToken);
        return users;
    }
}
