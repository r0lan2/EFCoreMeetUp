using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DataTests.Helpers
{
    public static class EfOptionsHelper
    {
        /// <summary>
        /// This creates a new and seeded database every time, with a name that is unique to the class that called it
        /// </summary>
        public static DbContextOptions<BloggingContext> SetupOptions<T>(this T testClass,bool seedData,bool deleteDatabase=true)
        {
            var optionsBuilder = SetupOptionsWithCorrectConnection(testClass);
            EnsureDatabaseIsCreatedAndSeeded(optionsBuilder.Options, seedData, deleteDatabase);

            return optionsBuilder.Options;
        }




        
        private  static DbContextOptionsBuilder<BloggingContext> SetupOptionsWithCorrectConnection<T>(T testClass)
        {
            var connection = testClass.GetUniqueDatabaseConnectionString();
            var optionsBuilder =
                new DbContextOptionsBuilder<BloggingContext>();

            optionsBuilder.UseSqlServer(connection);
            return optionsBuilder;
        }

        private static void EnsureDatabaseIsCreatedAndSeeded(DbContextOptions<BloggingContext> options, bool seedDatabase, bool deleteDatabase)
        {
            using (var context = new BloggingContext(options))
            {
                if (deleteDatabase)
                    context.Database.EnsureDeleted();

                context.Database.Migrate();

                if ( seedDatabase)
                    context.SeedDatabase();
            }
        }
    }
}
