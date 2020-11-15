using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace LegacyAppConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blogReader= new BlogReader();
            var blogs = blogReader.GetBlogs();

            foreach (var blog in blogs)
            {
                Console.WriteLine(blog.Name);
            }

            Console.ReadKey();
        }

    }

    public class BlogReader
    {

        public List<Blog> GetBlogs()
        {
            List<Blog> blogs= new List<Blog>();
            using (var conn = new SqlConnection(GetConnnectionString()))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Blogs";
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["Url"].ToString();
                            var id = int.Parse(reader["BlogId"].ToString() ?? string.Empty) ;
                            blogs.Add(new Blog(){BlogId = id,Name = name});
                        }
                    }
                }
            }
            return blogs;
        }

       
        public string GetConnnectionString()
        {
            var builder=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            var connectionstr = builder.Build().GetConnectionString("DefaultConnection");
            return connectionstr;

        }
    }

    public class Blog 
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }

}
