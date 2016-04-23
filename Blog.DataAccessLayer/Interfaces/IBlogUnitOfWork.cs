using Blog.DataAccessLayer.Identity;
using Blog.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace Blog.DataAccessLayer.Interfaces
{
    public interface IBlogUnitOfWork : IDisposable
    {
        IBlogManager<Article> Articles { get; }
        IBlogManager<Tag> Tags { get; }
        IBlogManager<Feedback> Feedbacks { get; }
        ApplicationRoleManager RoleManager { get; }
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }

        Task SaveAsync();
        void Save();
    }
}
