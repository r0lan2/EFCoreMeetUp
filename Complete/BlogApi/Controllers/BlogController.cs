using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController: ControllerBase
    {
        private BloggingContext _context;
        
        public BlogController(BloggingContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Blogs.Include(bp=>bp.Posts).Select(b => new
            {
                Url= b.Url,
                Posts= b.Posts
            }).ToList());
        }





    }
}
