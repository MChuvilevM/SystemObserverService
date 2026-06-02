using SystemObserver.Worker;

IHost builder = Host.CreateApplicationBuilder(args);
// В будущем здесь будет добавление сервисов
IHost host = builder.Build();
host.Run();
