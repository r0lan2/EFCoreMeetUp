using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogEngineDbLegacyContext())
            {
                var blogs = context.Blogs;
                foreach (var blog in blogs)
                {
                    Console.WriteLine(blog.Url);
                }
            }

            Console.ReadKey();
        }
    }
}
