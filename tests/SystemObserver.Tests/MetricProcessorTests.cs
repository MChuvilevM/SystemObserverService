using Moq;
using SystemObserver.Application.Services;
using SystemObserver.Domain.Interfaces;
using SystemObserver.Domain.Models;
using Xunit;

namespace SystemObserver.Tests;

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

    [Fact]
    public async Task ProcessAsync_ShouldNotCallRepository_WhenMetricIsInvalid()
    {
        var mockRepo = new Mock<IMetricRepository>();
        var processor = new MetricProcessor(mockRepo.Object);
        var invalidMetric = new SystemMetric("CPU", -1, DateTime.UtcNow);

        await processor.ProcessAsync(invalidMetric, CancellationToken.None);

        mockRepo.Verify(r => r.SaveMetricAsync(It.IsAny<SystemMetric>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
