using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;
using DataTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
namespace DataTests.Helpers
{
    public class TestBase:IAsyncLifetime
    {
        private readonly ITestOutputHelper _output;
        protected LogDbContext logIt;

        Task IAsyncLifetime.InitializeAsync()
        {
            return Task.CompletedTask;
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            if (logIt != null)
            {
                foreach (var log in logIt.Logs)
                {
                    _output.WriteLine(log);
                }
            }

            return Task.CompletedTask;
        }


        public TestBase(ITestOutputHelper output)
        {
            _output = output;
        }

    }
}
