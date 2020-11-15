using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEF3.Samples
{
    public class ClientEvaluationTest
    {

        public void Run(DbContextOptions<BlogContext> builderOptions)
        {
            using (var context = new BlogContext(builderOptions))
            {
                //var posts = context.Posts.Where(p => p.Content.Contains("C#") && FilterByDate(p.CreateTime));

                var posts = context.Posts.Where(p => p.Content.Contains("C#")).AsEnumerable()
                    .Where(p => FilterByDate(p.CreateTime));


                foreach (var post in posts)
                {
                    Console.WriteLine(post.Title);
                }

            }
        }

        private bool FilterByDate(DateTime value)
        {
            return value >= DateTime.Today;
        }

    }
}
