using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}