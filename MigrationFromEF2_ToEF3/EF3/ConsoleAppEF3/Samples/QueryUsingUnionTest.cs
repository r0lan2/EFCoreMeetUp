using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEF3.Samples
{
    public class QueryUsingUnionTest
    {
        public void Run(DbContextOptions<BlogContext> builderOptions)
        {
            using (var context = new BlogContext(builderOptions))
            {
                var blogs = context.Blogs.Where(b => b.Url.Contains(".net"));
                var blogs1 = context.Blogs.Where(b => b.Url.Contains("blog"));

                var result = blogs.Union(blogs1);

                foreach (var blog in result)
                {
                    Console.WriteLine(blog.Url);
                }

            }
        }
    }
}
