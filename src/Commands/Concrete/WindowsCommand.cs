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
            ProcessStartInfo startInfo = GetBaseStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command;

            return startInfo;
        }
    }
}
