using Leaderboard.Application;

namespace Leaderboard.API;

public static class Services
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCaching(builder.Configuration);
        builder.Services.AddApplication();
        builder.Services.AddDb(builder.Configuration);
        return builder;
    }
}