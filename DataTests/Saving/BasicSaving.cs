using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;
using DataTests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace DataTests.Saving
{
    public class BasicSaving:TestBase
    {
        public BasicSaving(ITestOutputHelper output):base(output)
        {
        }

      
        
        [Fact]
        public void AddingANewBlog()
        {
            var options = this.SetupOptions(seedData:false);
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

            using  (var context = new BloggingContext(options))
            {
                logIt = new LogDbContext(context);
                context.Blogs.Add(blog);
                context.SaveChanges();
                numberOfBlogs = context.Blogs.Count();
            }
           
            Assert.Equal(1,numberOfBlogs);

        }


        [Fact]
        public void RemoveBlog()
        {
            var options = this.SetupOptions(seedData:true);



            using var context = new BloggingContext(options);
            logIt = new LogDbContext(context);
            var numberOfBlogBeforeDelete = context.Blogs.Count();

            var blog =  context.Blogs.First();
            context.Blogs.Remove(blog);
            context.SaveChanges();


            var numberOfBlogAfterDelete = context.Blogs.Count();

            Assert.True(numberOfBlogBeforeDelete> numberOfBlogAfterDelete);
            Assert.True(numberOfBlogBeforeDelete -1 == numberOfBlogAfterDelete);

        }


        [Fact]
        public void UpdateBlog()
        {
            var options = this.SetupOptions(seedData:true);
            
            using var context = new BloggingContext(options);

            logIt = new LogDbContext(context);
           
            var blog =  context.Blogs.First();
            var newblogName="http://barrapunto.com";

            blog.Url = newblogName;

            context.SaveChanges();

            var blogAfterUpdate = context.Blogs.Single(b => b.Url == newblogName);

            Assert.NotNull(blogAfterUpdate);


        }







    }
}
