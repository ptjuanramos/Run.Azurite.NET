using System.Diagnostics;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class WindowsCommand : Command
    {

        public WindowsCommand(IProcessProxy processProxy) : base(processProxy)
        {
        }

        protected override ProcessStartInfo GetProcessStartInfo(string command)
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
    }
}
