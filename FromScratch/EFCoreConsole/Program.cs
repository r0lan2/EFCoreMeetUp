using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EFCoreConsole
{

    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {
                var blog = new Blog()
                {
                    Url = "www.asp.net",
                    Author = "nn",
                    Posts = new List<Post>()
                    {
                        new Post()
                        {
                            Title = "este es mi titulo",
                            Content = "este es mi contenido"
                        }
                    }
                };
                context.Blogs.Add(blog);
                context.SaveChanges();

                var blogsFromDb = context.Blogs.ToList();
                foreach (var b in blogsFromDb)
                {
                    Console.WriteLine(b.Url);
                }

            }

            Console.ReadKey();

        }
    }
}
