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
    public class BasicQueries:TestBase
    {
     
        public BasicQueries(ITestOutputHelper output):base(output)
        {
        }
        


        [Fact]
        public void FirstQueryInEfCore()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogs = context.Blogs.ToList();

            Assert.NotEmpty(blogs);
        }


         
        [Fact]
        public void QueryWithFilter()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogs = context.Blogs.Where(b=>b.Url=="Blog 1");

            Assert.NotEmpty(blogs);
        }


        [Fact]
        public void QueryUsingJoins()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogsExtended = from blog in context.Blogs
                join post in context.Posts on blog.BlogId equals post.BlogId
                select new
                {
                    blogUrl= blog.Url,
                    PostContent= post.Content
                };

            Assert.NotEmpty(blogsExtended);
        }


        [Fact]
        public void QueryUsingLefJoins()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogsExtended = from blog in context.Blogs
                join post in context.Posts on blog.BlogId equals post.BlogId
                into grouping  
                from post in grouping.DefaultIfEmpty()
                select new
                {
                    blogUrl= blog.Url,
                    PostContent= post.Content
                };

            Assert.NotEmpty(blogsExtended);
        }




        [Fact]
        public void QueryUsingJoinsLambda()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogsExtended = context.Blogs.Join(context.Posts, b => b.BlogId, p => p.BlogId, (b, p) => new 
            {
                blogUrl= b.Url,
                PostContent= p.Content
            });

            Assert.NotEmpty(blogsExtended);
        }


        [Fact]
        public void QueryUsingJoinsAndGroupBy()
        {
            var options = this.SetupOptions(seedData:true);

            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);

            var blogsExtended = from blog in context.Blogs
                join post in context.Posts on blog.BlogId equals post.BlogId
                group blog by blog.BlogId into g
                select new
                {
                    blogId= g.Key,
                    Post= g
                };


            Assert.NotEmpty(blogsExtended);
        }

















       











    }
}
