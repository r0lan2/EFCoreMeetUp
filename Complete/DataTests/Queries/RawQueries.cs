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

namespace DataTests.Queries
{
    public class RawQueries:TestBase
    {
       
        public RawQueries(ITestOutputHelper output):base(output)
        {
          
        }

        
        [Fact]
        public void CallingView()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogs = context.BlogStats.Where(b=> b.BlogId==1).ToList();

            Assert.NotEmpty(blogs);
        }


        [Fact]
        public void CallingStoredProcedure()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var sql = "GetBlogStats";
            var blogReports = context.Set<BlogReport>().FromSqlRaw(sql).ToList();

            Assert.NotEmpty(blogReports);
        }




    }
}
