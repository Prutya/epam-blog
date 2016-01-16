using EpamBlog.Model;
using System.Data.Entity;

namespace EpamBlog.DataAccess
{
    public class BlogDbContext : DbContext, IBlogDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public BlogDbContext()
            :base("BlogDbConnectionString")
        {
            Database.SetInitializer(new BlogDbInitializer());
        }
    }
}
