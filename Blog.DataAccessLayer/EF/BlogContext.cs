using Blog.DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Blog.DataAccessLayer.EF
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
        {

        }

        public BlogDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BlogDbContext>());
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(o => o.UserId);
            modelBuilder.Entity<IdentityRole>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(o => new { o.RoleId, o.UserId });

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
                .WillCascadeOnDelete(true);
        }
    }
}
