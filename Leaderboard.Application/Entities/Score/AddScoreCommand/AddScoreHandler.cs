using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;

namespace Leaderboard.Application.Entities.Score.AddScoreCommand;

public class AddScoreCommandHandler(LeaderboardDbContext dbContext) : IRequestHandler<AddScoreCommand, TableScore?>
{
    public async Task<TableScore?> Handle(AddScoreCommand request, CancellationToken cancellationToken)
    {
        var score = await dbContext.Scores.AddAsync(new TableScore()
        {
            PeriodStart = request.PeriodStart,
            PeriodEnd = request.PeriodEnd,
            ActivityId = request.ActivityId,
            Value = request.Value,
            UserCreatedId = request.UserId,
            UserUpdatedId = request.UserId,
            DateUpdated = DateTime.Now,
            DateCreated = DateTime.Now
        }, cancellationToken);
        return score.Entity;
    }
}