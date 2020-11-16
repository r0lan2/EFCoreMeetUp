using System;
using System.Collections.Generic;

namespace EFCoreConsole
{
    public partial class Blogs
    {
        public Blogs()
        {
            Posts = new HashSet<Posts>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
