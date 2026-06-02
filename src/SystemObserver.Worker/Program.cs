using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SystemObserver.Application.Services;
using SystemObserver.Infrastructure;
using SystemObserver.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddSingleton<MetricProcessor>();
builder.Services.AddHostedService<Worker>();

using IHost host = builder.Build();
host.Run();
