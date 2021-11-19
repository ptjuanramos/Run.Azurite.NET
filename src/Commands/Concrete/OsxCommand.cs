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
            throw new NotImplementedException();
        }
    }
}
