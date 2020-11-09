using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           using (var context= new BlogContext())
           {
              

               context.Blogs.Add(new Blog()
               {
                   Name = "This is a blog",
                   Posts = new List<Post>() {new Post(){Content = "new content"}}
               });
               context.SaveChanges();


               var blogs= context.Blogs.ToList();
               Console.WriteLine(blogs.Count);

           }
        }
    }
}
