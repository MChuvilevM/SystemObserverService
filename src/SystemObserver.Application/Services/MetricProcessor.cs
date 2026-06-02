using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SystemObserver.Application.Models;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Application.Services;

public class MetricProcessor(
    IMetricRepository repository, 
    IOptions<MetricSettings> settings,
    ILogger<MetricProcessor> logger)
{
    public async Task ProcessAsync(SystemMetric metric, CancellationToken ct)
    {
        if (!IsValid(metric))
        {
            logger.LogWarning("Отфильтрована невалидная метрика: {Name}, Значение: {Value}", 
                metric.MetricName, metric.Value);
            return;
        }

        await repository.SaveMetricAsync(metric, ct);
    }

    private bool IsValid(SystemMetric metric)
    {
        return metric.Value >= 0 && !string.IsNullOrWhiteSpace(metric.MetricName);
    }
}
