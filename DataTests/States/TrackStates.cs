using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Models;
using DataTests.Helpers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit;
using Xunit.Abstractions;

namespace DataTests.States
{
    public class TrackStates:TestBase
    {

        public TrackStates(ITestOutputHelper output):base(output)
        {
        }

        [Fact]
        public void GetABlog()
        {
            var options = this.SetupOptions(seedData:true);

            using (var context = new BloggingContext(options))
            {
                var blogs = context.Blogs.First();
                DisplayStates(context.ChangeTracker.Entries());
            }
        }


        [Fact]
        public void DeleteBlog()
        {
            var options = this.SetupOptions(seedData:true);

            using (var context = new BloggingContext(options))
            {
                var blog = context.Blogs.First();
                context.Blogs.Remove(blog);
                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        [Fact]
        public void AddnewBlog()
        {
            var options = this.SetupOptions(seedData:true);

            using (var context = new BloggingContext(options))
            {
                var blog = new Blog()
                {
                    Url = "http://tublog.cl"
                };
                context.Blogs.Add(blog);
                DisplayStates(context.ChangeTracker.Entries());
            }
        }


        [Fact]
        public void UpdateBlog()
        {
            var options = this.SetupOptions(seedData:true);

            using (var context = new BloggingContext(options))
            {
                var blog = context.Blogs.First();
                blog.Url = "none";
                context.Blogs.Update(blog);
                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        [Fact]
        public void DisconnectedEntity()
        {
            var options = this.SetupOptions(seedData:true);
            var blog = new Blog() {Url = "niceurl"};

            using (var context = new BloggingContext(options))
            {
                _output.WriteLine(context.Entry(blog).State.ToString());
            }
        }


        private  void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
               _output.WriteLine($"Entity: {entry.Entity.GetType().Name},State: {entry.State.ToString()} ");
            }
        }
    }
}
