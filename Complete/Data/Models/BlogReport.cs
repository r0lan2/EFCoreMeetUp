using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
   
    public class BlogReport
    {
        public string BlogName { get; set; }
        public int NumberOfPosts { get; set; }
    }
}
