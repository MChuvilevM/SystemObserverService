using SystemObserver.Domain.Models;

namespace SystemObserver.Domain.Interfaces;

public interface IMetricRepository
{
    Task SaveMetricAsync(SystemMetric metric, CancellationToken ct);
}
