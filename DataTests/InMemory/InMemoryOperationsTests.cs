using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Models;
using DataTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace DataTests.InMemory
{
    public class InMemoryOperationsTests:TestBase
    {

        public InMemoryOperationsTests(ITestOutputHelper output):base(output)
        {
        }

        

        public  DbContextOptionsBuilder<BloggingContext> SetInMemoryOptions()
        {
          
            var builder =
                new DbContextOptionsBuilder<BloggingContext>();

            builder.UseInMemoryDatabase("rola");
            return builder;
        }




        [Fact]
        public void QueryUsingInMemoryProvider()
        {
            var contextOptions = SetInMemoryOptions();

            using var context = new BloggingContext(contextOptions.Options);

            logIt = new LogDbContext(context);

            var blogs = context.Blogs.ToList();

            Assert.Empty(blogs);
        }


         
        [Fact]
        public void AddingANewBlog()
        {
            var contextOptions = SetInMemoryOptions();
            int numberOfBlogs = 0;
            var blog = new Blog()
            {
                Url = "http://blog1.com",
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Content = "my first content!",
                        Title = "this is my first post!"
                    }
                }
            };

            using  (var context = new BloggingContext(contextOptions.Options))
            {
                logIt = new LogDbContext(context);
                context.Blogs.Add(blog);
                context.SaveChanges();
                numberOfBlogs = context.Blogs.Count();
            }
           
            Assert.Equal(1,numberOfBlogs);

        }




    }
}
