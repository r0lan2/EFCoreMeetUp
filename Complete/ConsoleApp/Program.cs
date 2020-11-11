using System;
using System.IO;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();

            optionsBuilder.UseSqlServer(GetConnectionString());
            return optionsBuilder.Options;

        }

        public static string GetConnectionString()
        {
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            var connectionstr = builder.Build().GetConnectionString("DefaultConnection");
            return connectionstr;
        }



    }
}
