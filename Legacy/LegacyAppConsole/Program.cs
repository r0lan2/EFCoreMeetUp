using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LegacyAppConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blogReader= new BlogReader();
            var blogs = blogReader.GetBlogs();
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

        //TODO: add code to reead connection string from configuration file
        public string GetConnnectionString()
        {
            return "Server=PCRMARTINEZ\\SQL2016;Database=BlogEngineDbLegacy;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }

    public class Blog 
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
    }

}
