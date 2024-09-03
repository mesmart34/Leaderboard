namespace Leaderboard.Infrastructure.Config;

public class RedisSettings
{
    public const string ConfigSection = "RedisSettings";
    
    public string Endpoint { get; set; } = null!;
    public string Password { get; set; } = null!;
}