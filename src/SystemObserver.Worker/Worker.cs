using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SystemObserver.Application.Models;
using SystemObserver.Application.Services;
using SystemObserver.Domain.Models;

namespace SystemObserver.Worker;

public class Worker(MetricProcessor processor, IOptions<MetricSettings> settings, ILogger<Worker> logger) : BackgroundService
{
    private readonly MetricProcessor _processor = processor;
    private readonly MetricSettings _settings = settings.Value;
    private readonly ILogger<Worker> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker started at: {time} with interval {interval}s", DateTimeOffset.Now, _settings.IntervalSeconds);
        
        while (!stoppingToken.IsCancellationRequested)
        {
            var metric = new SystemMetric("CPU", 25.5, DateTime.UtcNow);
            await _processor.ProcessAsync(metric, stoppingToken);
            
            await Task.Delay(TimeSpan.FromSeconds(_settings.IntervalSeconds), stoppingToken);
        }
    }
}
