using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Infrastructure.Repositories;

public class FileMetricRepository : IMetricRepository
{
    public async Task SaveMetricAsync(SystemMetric metric, CancellationToken ct)
    {
        // Для примера просто пишем в консоль или лог
        await Console.Out.WriteLineAsync($"[Infrastructure] Saving: {metric.MetricName} = {metric.Value}");
    }
}
