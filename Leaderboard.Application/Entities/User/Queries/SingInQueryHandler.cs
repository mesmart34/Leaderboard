using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard.Application.Entities.User.Queries;

public class SingInQueryHandler(LeaderboardDbContext dbContext) : IRequestHandler<SingInQuery, TableUser?>
{
    public async Task<TableUser?> Handle(SingInQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken: cancellationToken);
    }
}