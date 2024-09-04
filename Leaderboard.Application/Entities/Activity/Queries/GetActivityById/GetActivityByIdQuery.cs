using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Queries;

public class GetActivityByIdQuery : IRequest<TableActivity?>
{
    public Guid Id { get; set; }
}