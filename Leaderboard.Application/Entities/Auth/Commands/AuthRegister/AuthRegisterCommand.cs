using System.ComponentModel.DataAnnotations;
using Leaderboard.Domain.Entities;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Leaderboard.Application.Entities.Auth.Commands.AuthRegister;

public class AuthRegisterCommand : IRequest<TableUser?>
{
    [Required]
    [SwaggerSchema("First name")]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [SwaggerSchema("Last name")]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [SwaggerSchema("Email")]
    public string Email { get; set; } = string.Empty;
    [Required]
    [SwaggerSchema("Password")]
    public string Password { get; set; } = string.Empty;
}
