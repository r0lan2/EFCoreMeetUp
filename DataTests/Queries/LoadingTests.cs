using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using DataTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;
namespace DataTests.Queries
{
    public class LoadingTests:TestBase
    {
        public LoadingTests(ITestOutputHelper output):base(output)
        {
        }



        [Fact]
        public void QueryUsingEagerLoading()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogs = context.Blogs.Include(b=>b.Posts).ToList();

            var firstBlogWithPosts = blogs.First();
            
            Assert.NotEmpty(firstBlogWithPosts.Posts);

        }

        [Fact]
        public void QueryUsingExplicitLoading()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);
          
           
            var blog = context.Blogs.Single(b => b.BlogId == 1);

            context.Entry(blog)
                .Collection(b => b.Posts)
                .Load();

            Assert.NotEmpty(blog.Posts);
        }


        [Fact]
        public void QueryUsingLazyLoading()
        {
            //TODO: add options to allow lazy loading
        }


    }
}
