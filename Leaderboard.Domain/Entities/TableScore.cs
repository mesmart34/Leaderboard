using Leaderboard.Domain.Contracts;

namespace Leaderboard.Domain.Entities;

public class TableScore : IHasId, IHasDateCreatedAndUpdated, IHasUserUpdatedAndCreated, IHasUserUpdatedAndCreatedReference
{
    public Guid Id { get; set; }
    
    public Guid ActivityId { get; set; }
    public virtual TableActivity Activity { get; set; } = null!;
    
    public DateTime PeriodStart { get; set; }
    public DateTime PeriodEnd { get; set; }
    
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    
    public Guid UserCreatedId { get; set; }
    public virtual TableUser UserCreated { get; set; } = null!;
    
    public Guid UserUpdatedId { get; set; }
    public virtual TableUser UserUpdated { get; set; } = null!;
}