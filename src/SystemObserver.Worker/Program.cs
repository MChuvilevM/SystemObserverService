using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemObserver.Application.Models;
using SystemObserver.Application.Services;
using SystemObserver.Infrastructure;
using SystemObserver.Worker; // Этот using обязателен!

var builder = Host.CreateApplicationBuilder(args);

builder.Services.Configure<MetricSettings>(
    builder.Configuration.GetSection("MetricSettings"));

builder.Services.AddInfrastructure();
builder.Services.AddSingleton<MetricProcessor>();
builder.Services.AddHostedService<Worker>(); // Теперь класс Worker найден

using IHost host = builder.Build();
host.Run();
