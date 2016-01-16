using EpamBlog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess
{
    public interface IBlogDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }

        int SaveChanges();
    }
}
