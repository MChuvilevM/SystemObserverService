using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SystemObserver.Application.Services;
using SystemObserver.Domain.Models;

namespace SystemObserver.Worker;

public class Worker(MetricProcessor processor, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var metric = new SystemMetric("CPU", 25.5, DateTime.UtcNow);
            await processor.ProcessAsync(metric, stoppingToken);
            
            await Task.Delay(5000, stoppingToken);
        }
    }
}
