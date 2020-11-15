using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEF3.Samples
{
    public class UnionPagingTest
    {

        public void Run(DbContextOptions<BlogContext> builderOptions)
        {
            using (var context = new BlogContext(builderOptions))
            {
                var blogsQuery1 = context.Blogs.Where(b => b.Url.Contains(".net"));
                var blogsQuery2 = context.Blogs.Where(b => b.Url.Contains("blog"));

                var blogsQuery3 = blogsQuery1.Union(blogsQuery2);

                var result = blogsQuery3.OrderByDescending(b => b.Posts.Count).Skip(0).Take(2);

                foreach (var blog in result)
                {
                    Console.WriteLine(blog.Url);
                }

            }
        }
    }
}
