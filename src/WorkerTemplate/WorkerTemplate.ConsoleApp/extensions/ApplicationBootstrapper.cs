using Microsoft.Extensions.DependencyInjection;

namespace WorkerTemplate.ConsoleApp.Extensions
{
    public static class ApplicationBootstrapper
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, WorkerParams workerParams)
        {
            return services;
                 //.AddSingleton<IInterface, ServiceClassName>();
        }
    }
}

