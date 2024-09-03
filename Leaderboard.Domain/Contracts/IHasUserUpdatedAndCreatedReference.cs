using Leaderboard.Domain.Entities;

namespace Leaderboard.Domain.Contracts;

public interface IHasUserUpdatedAndCreatedReference
{
    public TableUser UserCreated { get; set; }
    public TableUser UserUpdated { get; set; }
}