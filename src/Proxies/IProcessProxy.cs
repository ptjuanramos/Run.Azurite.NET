using System.Diagnostics;

namespace Run.Azurite.NET
{
    public interface IProcessProxy
    {
        bool Start(ProcessStartInfo startInfo);
    }
}