using Microsoft.Extensions.DependencyInjection;
using Run.Azurite.NET.Commands;
using Run.Azurite.NET.Commands.Concrete;
using Run.Azurite.NET.Proxies;
using System.Diagnostics;

namespace Run.Azurite.NET
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLocalAzurite(this IServiceCollection services)
        {
            services.AddTransient<Process>();
            services.AddTransient<IProcessProxy, ProcessProxy>();
            services.AddTransient<ICommandFactory, CommandFactory>();
            services.AddTransient<IAzuriteCommand, AzuriteCommand>();
            services.AddHostedService<LocalAzuriteHostedService>();
        }
    }
}
