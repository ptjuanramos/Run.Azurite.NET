using System;
using System.Diagnostics;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class OsxCommand : Command
    {
        public OsxCommand(IProcessProxy processProxy) : base(processProxy)
        {
        }

        protected override ProcessStartInfo GetProcessStartInfo(string command)
        {
            ProcessStartInfo startInfo = GetBaseStartInfo();
            startInfo.FileName = "";

            return startInfo;
            throw new NotImplementedException();
        }
    }
}
