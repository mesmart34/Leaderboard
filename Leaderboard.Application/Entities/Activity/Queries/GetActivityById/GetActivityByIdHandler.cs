using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard.Application.Entities.Activity.Queries;

public class GetActivityByIdHandler(LeaderboardDbContext dbContext) : IRequestHandler<GetActivityByIdQuery, TableActivity?>
{
    public async Task<TableActivity?> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await dbContext.Activities.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        return activity;
    }
}