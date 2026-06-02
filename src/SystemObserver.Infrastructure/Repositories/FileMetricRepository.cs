using Microsoft.Extensions.Logging;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;

namespace SystemObserver.Infrastructure.Repositories;

public class FileMetricRepository : IMetricRepository
{
    private readonly string _filePath = "metrics.log";
    private const long MaxFileSize = 1 * 1024 * 1024;
    private readonly ILogger<FileMetricRepository> _logger;

    public FileMetricRepository(ILogger<FileMetricRepository> logger)
    {
        _logger = logger;
    }

    public async Task SaveMetricAsync(SystemMetric metric, CancellationToken ct)
    {
        try
        {
            if (File.Exists(_filePath) && new FileInfo(_filePath).Length > MaxFileSize)
            {
                File.Move(_filePath, $"{_filePath}.old", true);
            }

            var logLine = $"{metric.Timestamp:yyyy-MM-dd HH:mm:ss} | {metric.MetricName}: {metric.Value}{Environment.NewLine}";
            await File.AppendAllTextAsync(_filePath, logLine, ct);
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, "Ошибка записи метрики в файл {FilePath}", _filePath);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Критическая ошибка при работе с файлом метрик");
            throw;
        }
    }
}
