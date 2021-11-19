using Microsoft.Extensions.Logging;

namespace Run.Azurite.NET.Commands.Concrete
{
    internal class AzuriteCommand : IAzuriteCommand
    {
        private readonly ILogger<AzuriteCommand> _logger;
        private readonly ICommandFactory _commandFactory;

        public AzuriteCommand(ILogger<AzuriteCommand> logger, ICommandFactory commandFactory)
        {
            _logger = logger;
            _commandFactory = commandFactory;
        }

        public bool Start()
        {
            ICommand command = _commandFactory.GetCommand();

            _logger.LogInformation("Running azurite command");
            return command.Run("azurite");
        }
    }
}
