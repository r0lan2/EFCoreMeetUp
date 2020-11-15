using System;
using System.Collections.Generic;
using System.IO;
using ConsoleAppEF3.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConsoleAppEF3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var seeder = new Seeder();
            //seeder.Seed();

            //new ClientEvaluationTest().Run(Seeder.GetOptions());
           //new QueryUsingUnionTest().Run(Seeder.GetOptions());
           new UnionPagingTest().Run(Seeder.GetOptions());

            Console.ReadKey();
        }
        
    }


    public class Seeder
    {

        public static DbContextOptions<BlogContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogContext>();

            optionsBuilder.UseSqlServer(GetConnectionString()).UseLoggerFactory(BlogContext.MyLoggerFactory);
            return optionsBuilder.Options;

        }

        public static string GetConnectionString()
        {
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            var connectionstr = builder.Build().GetConnectionString("DefaultConnection");
            return connectionstr;
        }

        public void Seed()
        {
            using (var conn = new BlogContext(GetOptions()))
            {
                conn.Database.Migrate();
                conn.Blogs.AddRange(GetBlogs(35));
                conn.SaveChanges();
            }
        }


        public List<Blog> GetBlogs(int numberOfBlogs)
        {
            var blogs = new List<Blog>();

            for (int i = 0; i < numberOfBlogs; i++)
            {
                blogs.Add( new Blog()
                {
                    Url = $"Blog {i}",
                    Posts = { new Post()
                        {
                            Content = "Content A" ,
                            Title = "Title A",
                            CreateTime = DateTime.Now
                        },
                        new Post()
                        {
                            Content = "Content B" ,
                            Title = "Title B",
                            CreateTime = DateTime.Now.AddDays(-1)
                        }
                    }
                });
            }
            return blogs;
        }


    }


}

