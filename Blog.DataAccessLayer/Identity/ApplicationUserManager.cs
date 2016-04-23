using Blog.DataAccessLayer.Models;
using Microsoft.AspNet.Identity;

namespace Blog.DataAccessLayer.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {

        }
    }
}
