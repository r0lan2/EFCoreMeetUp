using System;
using System.Collections.Generic;
using ConsoleAppEF2.Samples;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEF2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var seeder = new Seeder();
            //seeder.Seed();

            //new ClientEvaluationTest().Run();
            new QueryUsingUnionTest().Run();

            Console.ReadKey();
        }
        
    }


    public class Seeder
    {
        public void Seed()
        {
            using (var conn = new BlogContext())
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

