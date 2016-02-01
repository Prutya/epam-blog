using System;
using System.Data.Entity;
using System.Linq;

namespace Blog.DataAccessLayer.EF
{
    internal class BlogDbInitializer : DropCreateDatabaseAlways<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            

            context.SaveChanges();

            base.Seed(context);
        }
    }
}