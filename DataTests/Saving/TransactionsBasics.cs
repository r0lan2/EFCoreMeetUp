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

namespace DataTests.Saving
{
    public class TransactionsBasics:TestBase
    {
        public TransactionsBasics(ITestOutputHelper output):base(output)
        {
        }


        [Fact]
        public void UsingTransaction()
        {
            var options = this.SetupOptions(seedData:false);

            using var context = new BloggingContext(options);
            using var transaction = context.Database.BeginTransaction();
            logIt = new LogDbContext(context);

            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
            context.SaveChanges();

            context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet2" });
            context.SaveChanges();

            transaction.Commit();

            var blogs =  context.Blogs
                  .OrderBy(b => b.Url)
                 .ToList();

            Assert.NotEmpty(blogs);
           
        }


        
        [Fact]
        public void UsingTransactionWithRollback()
        {
            var options = this.SetupOptions(seedData:false);

            using var context = new BloggingContext(options);
            using var transaction = context.Database.BeginTransaction();
            logIt = new LogDbContext(context);

            try
            {
                context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
                context.SaveChanges();

                context.Blogs.Add(new Blog { Url = null });
                context.SaveChanges();

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
            catch (Exception)
            {
                // TODO: Handle failure
                //LogException(ex);
                transaction.Rollback();
            }

            var blogs =  context.Blogs
                .OrderBy(b => b.Url)
                .ToList();

            Assert.Empty(blogs);

        }


    }
}
