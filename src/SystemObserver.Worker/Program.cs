using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
using IHost host = builder.Build();
host.Run();
