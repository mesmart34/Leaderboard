using Leaderboard.Domain.Entities;
using Leaderboard.Infrastructure.Config;
using Leaderboard.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Leaderboard.API;

internal static class Db
{
    internal static IServiceCollection AddDb(this IServiceCollection services, IConfiguration config)
    {
        var dbConfig = config.GetSection(DatabaseSettings.ConfigSection).Get<DatabaseSettings>();
        if (string.IsNullOrWhiteSpace(dbConfig?.Endpoint))
        {
            throw new InvalidOperationException("DB endpoint is not set");
        }
        
        services.AddDbContextFactory<LeaderboardDbContext>(options =>
        {
            var npgsqlBuilder = new NpgsqlDataSourceBuilder(dbConfig.GetConnectionString());
            npgsqlBuilder.EnableDynamicJson();
            
            options
                .UseLazyLoadingProxies()
                .UseNpgsql(npgsqlBuilder.Build())
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }
    
    internal static async Task<IServiceProvider> InitializeDb(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<LeaderboardDbContext>>();

        await using var dbContext = await dbContextFactory.CreateDbContextAsync();

        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        await dbContext.SeedData();

        return services;
    }

    internal static async Task EnsureDatabaseIsUpToDateAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<LeaderboardDbContext>>();

        await using var dbContext = await dbContextFactory.CreateDbContextAsync();

        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

        if (pendingMigrations.Any())
        {
            throw new InvalidOperationException(
                "The DB appears to be not up-to-date as there are pending migrations found");
        }
    }

    private static async Task SeedData(this LeaderboardDbContext db)
    {
        var hasUsers = await db.Users.AnyAsync();
        if (!hasUsers)
        {
            await db.Users.AddRangeAsync(new List<TableUser>()
            {
                new TableUser()
                {
                    FirstName = "Артём",
                    LastName = "Екимов",
                    Email = "lolkek",
                    Password = "1488",
                    IsAdmin = true
                }
            });
        }

        await db.SaveChangesAsync();
    }
}