using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SystemObserver.Application.Models;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Infrastructure.Repositories;

namespace SystemObserver.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MetricSettings>(configuration.GetSection("MetricSettings"));
        services.AddSingleton<IMetricRepository, FileMetricRepository>();
        
        return services;
    }
}
