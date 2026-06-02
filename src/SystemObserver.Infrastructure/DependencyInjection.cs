using Microsoft.Extensions.DependencyInjection;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Infrastructure.Repositories;

namespace SystemObserver.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IMetricRepository, FileMetricRepository>();
        return services;
    }
}
