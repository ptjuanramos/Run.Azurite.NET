using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Run.Azurite.NET
{
    internal class LocalAzuriteHostedService : IHostedService
    {
        private readonly ILogger<LocalAzuriteHostedService> _logger;
        private readonly IAzuriteCommand _azuriteCommand;

        public LocalAzuriteHostedService(ILogger<LocalAzuriteHostedService> logger, IAzuriteCommand azuriteCommand)
        {
            _azuriteCommand = azuriteCommand;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                if (!_azuriteCommand.Start())
                {
                    _logger.LogError("Couldn't start azurite for some reason.");
                }

            }, cancellationToken);
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
