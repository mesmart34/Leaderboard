using Leaderboard.Domain.Entities;
using MediatR;

namespace Leaderboard.Application.Entities.User.Commands;

public class AddUserCommand : IRequest<TableUser?>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
}
