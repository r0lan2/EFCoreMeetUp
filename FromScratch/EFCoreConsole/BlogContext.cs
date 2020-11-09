
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsole
{
    public class BlogContext:DbContext
    {

        public DbSet<Post> Posts { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=PCRMARTINEZ\\SQL2016;Database=BlogDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        }



    }
}
