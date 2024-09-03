using Leaderboard.Domain.Contracts;

namespace Leaderboard.Domain.Entities;

public class TableUser : 
    IHasId,
    IHasDateCreatedAndUpdated
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}