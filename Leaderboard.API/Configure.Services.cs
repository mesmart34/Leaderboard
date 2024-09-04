using Leaderboard.API.Services;
using Leaderboard.Application;
using Leaderboard.Application.Contracts;

namespace Leaderboard.API;

public static class ConfigureServices
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCaching(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddDb(builder.Configuration);
        builder.Services.AddScoped<IAuthService, AuthService>();
        return builder;
    }
}