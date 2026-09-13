using Microsoft.Extensions.DependencyInjection;

namespace AgriTrack.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAgriTrackInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<DbConnectionFactory>();
        services.AddScoped<IStoredProcRepository, DapperStoredProcRepository>();
        return services;
    }
}
