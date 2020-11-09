using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Models;

namespace Data.Configuration
{
    public static class DataSeeder
    {


        public static void SeedDatabase(this BloggingContext context)
        {
            context.Blogs.AddRange(GetBlogs(10));
            context.SaveChanges();
        }


        public static List<Blog> GetBlogs(int numberOfBlogs)
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
                            Title = "Title A"
                        },
                        new Post()
                        {
                            Content = "Content B" ,
                            Title = "Title B"
                        }
                    }
                });
            }
            return blogs;
        }

    }
}
