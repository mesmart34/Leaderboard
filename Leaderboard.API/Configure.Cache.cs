using Leaderboard.Infrastructure.Config;

namespace Leaderboard.API;

internal static class Cache
{
    internal static void AddCaching(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        var redisConfig = configurationManager.GetSection(RedisSettings.ConfigSection).Get<RedisSettings>();
        if (string.IsNullOrWhiteSpace(redisConfig?.Endpoint))
        {
            throw new InvalidOperationException("Redis endpoint is not set");
        }
        
        serviceCollection.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = $"{redisConfig.Endpoint},password={redisConfig.Password}";
        });
    }
}