namespace SystemObserver.Application.Models;

public class MetricSettings
{
    public string StoragePath { get; set; } = "metrics.txt";
    public int IntervalSeconds { get; set; } = 5;
}
