using Blog.DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Blog.DataAccessLayer.EF
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new BlogDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Article>()
                .HasRequired(o => o.ClientProfile)
                .WithMany(o => o.Articles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(o => o.ClientProfile)
                .WithMany(o => o.Feedbacks)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasRequired(o => o.Article)
                .WithMany(o => o.Feedbacks)
                .WillCascadeOnDelete(false);
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
