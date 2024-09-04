using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Db;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Commands.AddActivity;

public class AddActivityHandler(LeaderboardDbContext dbContext) : IRequestHandler<AddActivityCommand, TableActivity>
{
    public async Task<TableActivity> Handle(AddActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = (await dbContext.Activities.AddAsync(new TableActivity()
        {
            Name = request.Name
        }, cancellationToken)).Entity;
        
        return activity;
    }
}