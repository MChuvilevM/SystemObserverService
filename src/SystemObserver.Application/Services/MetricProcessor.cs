using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Application.Services;

public class MetricProcessor(IMetricRepository repository)
{
    public async Task ProcessAsync(SystemMetric metric, CancellationToken ct)
    {
        // Здесь можно добавить бизнес-логику (валидация, пороги)
        if (metric.Value < 0) return; 
        
        await repository.SaveMetricAsync(metric, ct);
    }
}
