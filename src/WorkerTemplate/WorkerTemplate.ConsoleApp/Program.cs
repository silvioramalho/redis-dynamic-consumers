using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerTemplate.ConsoleApp;
using WorkerTemplate.ConsoleApp.Extensions;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        Console.WriteLine(hostContext.Configuration["WorkerIntervalActive"]);
        var workerParams = new WorkerParams()
        {
            //DBConnection = hostContext.Configuration.GetConnectionString("DBConnection"),
            WorkerIntervalActive = int.Parse(hostContext.Configuration["WorkerIntervalActive"]),
            WorkersNumber = hostContext.Configuration["WorkersNumber"] == null ? 1 : int.Parse(hostContext.Configuration["WorkersNumber"])
        };
        services.AddSingleton<WorkerParams>(workerParams);
        services.AddApplicationServices(workerParams);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();