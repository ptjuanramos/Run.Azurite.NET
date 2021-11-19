using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Run.Azurite.NET.Commands;
using Run.Azurite.NET.Commands.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run.Azurite.NET.Tests.Commands.Concrete
{
    [TestClass]
    public class AzuriteCommandTest
    {
        private LogLevel StubLoggerLogLevel;
        private StubLogger<AzuriteCommand> StubLogger;

        private readonly Mock<ICommand> _mockedCommand = new();
        private readonly Mock<ICommandFactory> _mockedCommandFactory = new();

        private AzuriteCommand azuriteCommand;

        [TestInitialize]
        public void SetUp()
        {
            StubLogger = new((logLevel, _) => StubLoggerLogLevel = logLevel);
            azuriteCommand = new(StubLogger, _mockedCommandFactory.Object);
            _mockedCommand.Setup(command => command.Run(It.IsAny<string>())).Returns(true);
        }

        [TestMethod]
        public void StartReturnsFalseAndLogsErrorMessageIfCommandFactoryReturnsNull()
        {
            Assert.IsFalse(azuriteCommand.Start());
            Assert.AreEqual(LogLevel.Error, StubLoggerLogLevel);
        }

        [TestMethod]
        public void StartReturnsTrueLogsInformingThatIsStartingAzuriteCommandAndRunsAzuriteCommand()
        {
            _mockedCommandFactory
                .Setup(commandFactory => commandFactory.GetCommand())
                .Returns(_mockedCommand.Object);

            Assert.IsTrue(azuriteCommand.Start());
            _mockedCommand.Verify(command => command.Run("azurite"));
            Assert.AreEqual(LogLevel.Information, StubLoggerLogLevel);
        }
    }
}
