using Microsoft.Extensions.DependencyInjection;

namespace Leaderboard.Application;

public static class DI
{
    public static IServiceCollection AddApp(this IServiceCollection serviceCollection)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            serviceCollection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assembly);
                cfg.Lifetime = ServiceLifetime.Singleton;
            });
        }

        return serviceCollection;
        // var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        // return serviceCollection.AddMediatR(cfg =>
        // {
        //     cfg.RegisterServicesFromAssemblies(assemblies);
        //     cfg.TypeEvaluator = x => x.ContainsGenericParameters;
        // });
    }
}
