using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Queries;

public class GetActivitiesQuery : IRequest<List<TableActivity>>
{
    
}