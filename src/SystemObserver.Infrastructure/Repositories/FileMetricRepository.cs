using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Infrastructure.Repositories;

public class FileMetricRepository : IMetricRepository
{
    private readonly string _filePath = "metrics.log";
    private const long MaxFileSize = 1 * 1024 * 1024; // 1 MB

    public async Task SaveMetricAsync(SystemMetric metric, CancellationToken ct)
    {
        if (File.Exists(_filePath) && new FileInfo(_filePath).Length > MaxFileSize)
        {
            File.Move(_filePath, $"{_filePath}.old", true);
        }

        var logLine = $"{metric.Timestamp:yyyy-MM-dd HH:mm:ss} | {metric.MetricName}: {metric.Value}{Environment.NewLine}";
        await File.AppendAllTextAsync(_filePath, logLine, ct);
    }
}
