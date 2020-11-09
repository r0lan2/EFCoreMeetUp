using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace DataTests.Helpers
{
    public static class AppSettings
    {
        public const string ConnectionStringName = "DefaultConnection";


        public static IConfigurationRoot GetConfiguration()
        {
            var testDir = Path.Combine(GetSolutionDirectory(), "DataTests");
            var builder = new ConfigurationBuilder()
                .SetBasePath(testDir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }

       
        public static string GetUniqueDatabaseConnectionString<T>(this T testClass)
        {
            var config = GetConfiguration();
            var connectionString = config.GetConnectionString(ConnectionStringName);
            //var builder = new SqlConnectionStringBuilder(orgConnect);

            //var extraDatabaseName = $".{typeof(T).Name}";

            //builder.InitialCatalog += extraDatabaseName;

            //return builder.ToString();

            return connectionString;
        }



        public static string GetSolutionDirectory()
        {
            var host = new ApplicationEnvironment();
            var pathToManipulate = host.ApplicationBasePath;

            var partToEndOn = typeof(AppSettings).FullName.Split('.').First() + @"\bin\";
            var indexOfPart = pathToManipulate.IndexOf(partToEndOn, StringComparison.OrdinalIgnoreCase);
            if (indexOfPart < 0)
                throw new Exception($"Did not find '{partToEndOn}' in the ApplicationBasePath");

            return pathToManipulate.Substring(0, indexOfPart - 1);

        }

    }
}