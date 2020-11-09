using System;
using System.Collections.Generic;
using System.Text;
using Data.Configuration;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<vBlogsStats> BlogStats { get; set; }
        public DbSet<BlogReport> BlogReports { get; set; }


        public BloggingContext(
            DbContextOptions<BloggingContext> options)
            : base(options)
        {

        }                            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());


            modelBuilder.Entity<vBlogsStats>().HasNoKey().ToView("vBlogsStats");
            modelBuilder.Entity<BlogReport>().HasNoKey().ToView(null);
        }
    }
}
