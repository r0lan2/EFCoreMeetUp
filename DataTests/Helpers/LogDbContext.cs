using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace DataTests.Helpers
{
    public class LogDbContext
    {
        private readonly List<string> _logs = new List<string>();

        public ImmutableList<string> Logs => _logs.ToImmutableList();

        public void ClearLogs()
        {
            _logs.Clear();
        }

        public LogDbContext(DbContext context, LogLevel logLevel = LogLevel.Information)
        {
            var loggerFactory = context.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new MyLoggerProvider(_logs, logLevel));
        }
    }
}
