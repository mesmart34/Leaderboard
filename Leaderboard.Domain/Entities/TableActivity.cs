using Leaderboard.Domain.Contracts;

namespace Leaderboard.Domain.Entities;

public class TableActivity : 
    IHasId,
    IHasUserUpdatedAndCreated,
    IHasDateCreatedAndUpdated,
    IHasUserUpdatedAndCreatedReference
    
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    
    public Guid UserCreatedId { get; set; }
    public virtual TableUser UserCreated { get; set; } = null!;
    public Guid UserUpdatedId { get; set; }
    public virtual TableUser UserUpdated { get; set; } = null!;
}