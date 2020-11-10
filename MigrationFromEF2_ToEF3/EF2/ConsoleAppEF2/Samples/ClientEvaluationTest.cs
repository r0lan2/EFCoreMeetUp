using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppEF2.Samples
{
    public class ClientEvaluationTest
    {

        public void Run()
        {
            using (var context = new BlogContext())
            {
                var posts = context.Posts.Where(p => p.Content.Contains("C#") && FilterByDate(p.CreateTime));
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
