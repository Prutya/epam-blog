using Blog.DataAccessLayer.EF;
using Blog.DataAccessLayer.Identity;
using Blog.DataAccessLayer.Interfaces;
using Blog.DataAccessLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccessLayer.Repositories
{
    public class BlogUnitOfWork : IBlogUnitOfWork
    {
        private readonly BlogDbContext _context;

        private IBlogManager<Article> articlesManager;
        private IBlogManager<Feedback> feedbacksManager;
        private IBlogManager<Tag> tagsManager;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        public BlogUnitOfWork(string connectionString)
        {
            _context = new BlogDbContext(connectionString);
        }

        public IBlogManager<Article> Articles
        {
            get
            {
                if (articlesManager == null)
                {
                    articlesManager = new GenericManager<Article>(_context);

                    DateTime currentTime = DateTime.Now;
                    var clients = _context.ClientProfiles.ToList();
                    _context.Articles.Add(new Models.Article()
                    {
                        Text = "Article1 text",
                        Title = "Article1",
                        TimeCreated = currentTime,
                        TimeEdited = currentTime,
                        ClientProfileId = clients[0].Id
                    }); _context.SaveChanges();
                }
                return articlesManager;
            }
        }
        public IBlogManager<Feedback> Feedbacks
        {
            get
            {
                if (feedbacksManager == null)
                {
                    feedbacksManager = new GenericManager<Feedback>(_context);
                }
                return feedbacksManager;
            }
        }
        public IBlogManager<Tag> Tags
        {
            get
            {
                if (tagsManager == null)
                {
                    tagsManager = new GenericManager<Tag>(_context);
                }
                return tagsManager;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                if (userManager == null)
                {
                    userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
                }
                return userManager;
            }
        }
        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (roleManager == null)
                {
                    roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
                }
                return roleManager;
            }
        }
        public IClientManager ClientManager
        {
            get
            {
                if (clientManager == null)
                {
                    clientManager = new ClientManager(_context);
                }
                return clientManager;
            }
        }

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();

        #region Dispose pattern
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
