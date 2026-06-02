using System.IO;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Infrastructure.Repositories;

public class FileMetricRepository : IMetricRepository
{
    private readonly string _filePath = "metrics.log";

    public async Task SaveMetricAsync(SystemMetric metric, CancellationToken ct)
    {
        var logLine = $"{metric.Timestamp:yyyy-MM-dd HH:mm:ss} | {metric.MetricName}: {metric.Value}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, logLine, ct);
    }
}
