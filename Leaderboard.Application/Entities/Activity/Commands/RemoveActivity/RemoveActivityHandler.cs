
using Leaderboard.Infrastructure.Db;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Commands.RemoveActivity;

public class RemoveActivityHandler(LeaderboardDbContext dbContext) : IRequestHandler<RemoveActivityCommand>
{
    public Task Handle(RemoveActivityCommand request, CancellationToken cancellationToken)
    {
        dbContext.Activities.Remove(request.Activity);
        return Task.CompletedTask;
    }
}