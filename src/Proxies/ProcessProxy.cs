using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Run.Azurite.NET.Proxies
{
    internal class ProcessProxy : IProcessProxy
    {
        private readonly Process _process;
        private readonly ILogger<ProcessProxy> _logger;

        public ProcessProxy(ILogger<ProcessProxy> logger, Process process)
        {
            _process = process;
            _logger = logger;
        }

        public bool Start(ProcessStartInfo startInfo)
        {
            _process.StartInfo = startInfo;
            _process.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputDataReceived);   

            bool startResult = _process.Start();

            _process.BeginOutputReadLine();

            return startResult;
        }

        private void ProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if(!string.IsNullOrEmpty(e.Data))
            {
                _logger.LogInformation(e.Data);
            }
        }
    }
}
