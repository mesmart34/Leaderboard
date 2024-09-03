using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.User.Queries;

public class GetUserByIdQuery : IRequest<TableUser?>
{
    public Guid Id { get; set; }
}
