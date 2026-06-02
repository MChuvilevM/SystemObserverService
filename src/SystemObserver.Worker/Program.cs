using SystemObserver.Application.Services;
using SystemObserver.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

// Подключаем наш слой инфраструктуры
builder.Services.AddInfrastructure();
// Регистрируем сервисы приложения
builder.Services.AddSingleton<MetricProcessor>();
// Регистрируем фоновую задачу
builder.Services.AddHostedService<Worker>();

using IHost host = builder.Build();
host.Run();
