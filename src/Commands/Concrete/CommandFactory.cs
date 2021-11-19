using System.Runtime.InteropServices;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly IProcessProxy _processProxy;

        public CommandFactory(IProcessProxy processProxy)
        {
            _processProxy = processProxy;
        }

        public ICommand GetCommand()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new WindowsCommand(_processProxy);

            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new LinuxCommand(_processProxy);

            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OsxCommand(_processProxy);
            }

            return null;
        }
    }
}
