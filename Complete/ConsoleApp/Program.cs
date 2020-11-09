using System;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context= new BloggingContext(connectionOptions()))
            {
                var count=context.Blogs.Count();
                Console.WriteLine(count);

            }
            Console.ReadKey();
        }


        public static DbContextOptions<BloggingContext> connectionOptions()
        {
            var connection = "Server=PCRMARTINEZ\\SQL2016;Database=BlogEngineDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();

            optionsBuilder.UseSqlServer(connection);
            return optionsBuilder.Options;

        }


    }
}
