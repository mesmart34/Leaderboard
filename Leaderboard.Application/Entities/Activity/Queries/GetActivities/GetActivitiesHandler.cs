using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leaderboard.Application.Entities.Activity.Queries.GetActivities;

public class GetActivitiesHandler(LeaderboardDbContext dbContext) : IRequestHandler<GetActivitiesQuery, List<TableActivity>>
{
    public async Task<List<TableActivity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Activities.ToListAsync(cancellationToken: cancellationToken);
    }
}