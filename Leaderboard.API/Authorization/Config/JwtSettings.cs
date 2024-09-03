namespace Leaderboard.API.Authorization.Config;

public class JwtSettings
{
    public const string ConfigSection = "JwtSettings";
    
    public string Key { get; set; } = null!;
    public string Issuer { get; set; } = null!;
}