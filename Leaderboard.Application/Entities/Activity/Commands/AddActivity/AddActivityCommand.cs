using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.Activity.Commands.AddActivity;

public class AddActivityCommand : IRequest<TableActivity>
{
    public string Name { get; set; } = null!;
}