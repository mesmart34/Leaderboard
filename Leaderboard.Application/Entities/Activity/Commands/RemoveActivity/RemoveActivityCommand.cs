using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Commands.RemoveActivity;

public class RemoveActivityCommand : IRequest
{
    public TableActivity Activity { get; set; } = null!;
}