using System.Diagnostics;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal abstract class Command : ICommand
    {
        public IProcessProxy _processProxy;

        public Command(IProcessProxy processProxy)
        {
            _processProxy = processProxy;
        }

        protected static ProcessStartInfo GetBaseStartInfo()
        {
            return new()
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }

        protected abstract ProcessStartInfo GetProcessStartInfo(string command);

        public bool Run(string command)
        {
            return _processProxy.Start(GetProcessStartInfo(command));
        }
    }
}
