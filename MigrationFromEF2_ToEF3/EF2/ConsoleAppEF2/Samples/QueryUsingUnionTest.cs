using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppEF2.Samples
{
    public class QueryUsingUnionTest
    {
        public void Run()
        {
            using (var context = new BlogContext())
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
