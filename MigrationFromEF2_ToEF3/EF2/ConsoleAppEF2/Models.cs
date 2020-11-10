using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ConsoleAppEF2
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }= new List<Post>();
    }


    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public DateTime CreateTime{ get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

    }

    public class BlogContext:DbContext
    {

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<Post> Posts { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=PCRMARTINEZ\\SQL2016;Database=BlogDbMigrated;Trusted_Connection=True;MultipleActiveResultSets=true")
              
                .UseLoggerFactory(MyLoggerFactory);

        }
    }





}
