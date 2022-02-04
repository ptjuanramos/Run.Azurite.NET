using System;
using System.Diagnostics;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class LinuxCommand : Command
    {
        public LinuxCommand(IProcessProxy processProxy) : base(processProxy)
        {
        }

        protected override ProcessStartInfo GetProcessStartInfo(string command)
        {
            ProcessStartInfo startInfo = GetBaseStartInfo();
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = "/dev/init.d/azurite";

            return startInfo;
        }
    }
}
