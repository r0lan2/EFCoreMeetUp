using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ConsoleAppEF3
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

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole();});


        public BlogContext(
            DbContextOptions<BlogContext> options)
            : base(options)
        {

        }  
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }





}
