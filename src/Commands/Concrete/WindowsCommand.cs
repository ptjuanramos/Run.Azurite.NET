using System.Diagnostics;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class WindowsCommand : ICommand
    {
        private readonly IProcessProxy _processProxy;

        public WindowsCommand(IProcessProxy processProxy)
        {
            _processProxy = processProxy;
        }

        private static ProcessStartInfo GetProcessStartInfo(string command)
        {
            return new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = "cmd.exe",
                Arguments = "/C " + command
            };

        }

        public bool Run(string command)
        {
            return _processProxy.Start(GetProcessStartInfo(command));
        }
    }
}
