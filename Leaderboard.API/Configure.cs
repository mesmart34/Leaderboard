namespace Leaderboard.API;

public static class Configure
{
    private static string _configDirectory = "Config";
    
    public static WebApplicationBuilder AddConfig(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        var env = builder.Environment;

        config
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"{_configDirectory}/database.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{_configDirectory}/redis.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        return builder;
    }
}