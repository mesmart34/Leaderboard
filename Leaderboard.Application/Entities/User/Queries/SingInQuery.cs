using System.ComponentModel.DataAnnotations;
using Leaderboard.Domain.Entities;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Leaderboard.Application.Entities.User.Queries;

public class SingInQuery : IRequest<TableUser?>
{
    [Required]
    [SwaggerSchema("Email")]
    public string Email { get; set; } = null!;
    [Required]
    [SwaggerSchema("Password")]
    public string Password { get; set; } = null!;
}