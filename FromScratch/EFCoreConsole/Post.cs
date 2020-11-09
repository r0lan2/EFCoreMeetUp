using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreConsole
{
    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }


    }
}
