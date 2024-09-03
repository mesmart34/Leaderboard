namespace Leaderboard.API;

public static class Configure
{
    private const string ConfigDirectory = "Config";

    public static WebApplicationBuilder AddConfig(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        var env = builder.Environment;

        config
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"{ConfigDirectory}/database.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{ConfigDirectory}/redis.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{ConfigDirectory}/security.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        return builder;
    }
}