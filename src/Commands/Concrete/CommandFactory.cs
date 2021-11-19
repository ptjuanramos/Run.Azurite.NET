using Microsoft.Extensions.DependencyInjection;
using Run.Azurite.NET.Proxies;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommand GetCommand()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                IProcessProxy processProxy = _serviceProvider.GetService<IProcessProxy>();
                return new WindowsCommand(processProxy);

            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new LinuxCommand();

            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OsxCommand();
            }

            return null;
        }
    }
}
