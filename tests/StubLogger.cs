using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run.Azurite.NET.Tests
{
    internal class StubLogger<T> : ILogger<T>
    {
        public bool WasLogged { get; private set; }

        private readonly Action<LogLevel, string> _loggerDelegate;

        public StubLogger(Action<LogLevel, string> loggerDelegate)
        {
            _loggerDelegate = loggerDelegate;
        }

        public StubLogger()
        {
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _loggerDelegate?.Invoke(logLevel, formatter(state, exception));
            WasLogged = true;
        }
    }
}
