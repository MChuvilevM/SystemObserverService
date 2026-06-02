using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SystemObserver.Application.Services; // ЭТОГО У ТЕБЯ НЕ ХВАТАЕТ

namespace SystemObserver.Worker;

public class Worker(MetricProcessor processor, ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);
        }
    }
}
