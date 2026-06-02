using SystemObserver.Application.Services;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;
using Moq;
using Xunit;

public class MetricProcessorTests
{
    [Fact]
    public async Task ProcessAsync_ShouldCallRepository_WhenMetricIsValid()
    {
        var mockRepo = new Mock<IMetricRepository>();
        var processor = new MetricProcessor(mockRepo.Object);
        var metric = new SystemMetric("CPU", 50.0, DateTime.UtcNow);

        await processor.ProcessAsync(metric, CancellationToken.None);

        mockRepo.Verify(r => r.SaveMetricAsync(metric, It.IsAny<CancellationToken>()), Times.Once);
    }
}
