namespace Leaderboard.Domain.Contracts;

public interface IHasUserUpdatedAndCreated
{
    public Guid UserCreatedId { get; set; }
    public Guid UserUpdatedId { get; set; }
}