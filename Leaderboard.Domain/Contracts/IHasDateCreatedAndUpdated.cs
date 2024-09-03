namespace Leaderboard.Domain.Contracts;

public interface IHasDateCreatedAndUpdated
{
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}