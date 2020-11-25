using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsole
{
    public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Url { get; set; }

        public string Author { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public class AppContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=PCRMARTINEZ\\SQL2016;Initial Catalog=BlogDb;Trusted_Connection=True");
            }
        }
    }
}
