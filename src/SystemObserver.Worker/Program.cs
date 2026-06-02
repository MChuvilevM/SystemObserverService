using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemObserver.Application.Models;
using SystemObserver.Application.Services;
using SystemObserver.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

// Добавляем биндинг настроек
builder.Services.Configure<MetricSettings>(
    builder.Configuration.GetSection("MetricSettings"));

builder.Services.AddInfrastructure();
builder.Services.AddSingleton<MetricProcessor>();
builder.Services.AddHostedService<Worker>();

using IHost host = builder.Build();
host.Run();
