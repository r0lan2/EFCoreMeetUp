using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
    }
}
