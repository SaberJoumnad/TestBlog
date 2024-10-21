using Microsoft.EntityFrameworkCore;
using TestBlog.Models.Entities;

namespace TestBlog.Models.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
