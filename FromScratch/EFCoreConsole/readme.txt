Data Source=PCRMARTINEZ\\SQL2016;Initial Catalog=BlogDb;Trusted_Connection=True


  public class Blog
    {

        public int BlogId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

    }


    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(300)]
        public string Content { get; set; }

        public Blog Blog { get; set; }

    }

    public class AppContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=PCRMARTINEZ\\SQL2016;Initial Catalog=BlogDb;Trusted_Connection=True");
            }
        }
    }




        using (var context = new AppContext())
            {


                context.Blogs.Add(new Blog()
                {
                    Url = "This is a blog",
                    Posts = new List<Post>() { new Post() { Content = "new content",Title = "a nice title"} }
                });
                context.SaveChanges();


                var blogs = context.Blogs.ToList();
                Console.WriteLine(blogs.Count);

            }
