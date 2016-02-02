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

            _context.Database.CreateIfNotExists();

            if (_context.Database.Exists())
            {
                if (!_context.Articles.Any())
                {
                    var task = Task.Run(SeedAsync);
                    task.Wait();
                }                    
            }
        }

        private async Task SeedAsync()
        {
            _context.Database.Initialize(false);
            string password = "P@ssw0rd!";
            string userRole = "User";
            string adminRole = "Admin";

            #region Create roles
            string[] roles = new string[] { "Admin", "User" };
            foreach (string role in roles)
            {
                await RoleManager.CreateAsync(new ApplicationRole { Name = role });
            }
            #endregion

            #region Create user1
            string user1Email = "user1@example.com";

            ApplicationUser user1 = new ApplicationUser()
            {
                Email = user1Email,
                UserName = user1Email
            };
            await UserManager.CreateAsync(user1, password);
            await UserManager.AddToRoleAsync(user1.Id, userRole);
            ClientProfile user1Profile = new ClientProfile
            {
                Id = user1.Id,
                LastName = "John",
                FirstName = "Doe"
            };
            ClientManager.Create(user1Profile);
            #endregion
            #region Create user2
            string user2Email = "user2@example.com";

            ApplicationUser user2 = new ApplicationUser()
            {
                Email = user2Email,
                UserName = user2Email
            };
            await UserManager.CreateAsync(user2, password);
            await UserManager.AddToRoleAsync(user2.Id, userRole);
            ClientProfile user2Profile = new ClientProfile
            {
                Id = user2.Id,
                LastName = "John",
                FirstName = "Smith"
            };
            ClientManager.Create(user2Profile);
            #endregion

            #region Create admin
            string adminEmail = "admin@example.com";
            string adminFirstName = "Admin";
            string adminLastName = "Admin";

            ApplicationUser admin = new ApplicationUser()
            {
                Email = adminEmail,
                UserName = adminEmail
            };
            await UserManager.CreateAsync(admin, password);
            await UserManager.AddToRoleAsync(admin.Id, userRole);
            await UserManager.AddToRoleAsync(admin.Id, adminRole);
            ClientProfile adminProfile = new ClientProfile
            {
                Id = admin.Id,
                LastName = adminLastName,
                FirstName = adminFirstName
            };
            ClientManager.Create(adminProfile);
            #endregion

            #region Create tags
            List<Tag> tags = new List<Tag>
            {
                new Tag { Text = "c#" },
                new Tag { Text = "java" },
                new Tag { Text = "php" },
                new Tag { Text = "c++" },
                new Tag { Text = "html" },
                new Tag { Text = "css" },
                new Tag { Text = "sql" },
                new Tag { Text = "objective-c" },
                new Tag { Text = "javascript" },
                new Tag { Text = "css3" },
                new Tag { Text = "html5" },
                new Tag { Text = "python" },
                new Tag { Text = "c" },
                new Tag { Text = ".net" },
                new Tag { Text = "web" },
                new Tag { Text = "mobile" }
            };

            foreach (Tag tag in tags)
            {
                Tags.Create(tag);
            }
            #endregion

            #region Create articles with feedbacks
            DateTime currentTime = DateTime.Now;
            List<Article> articles = new List<Article>
            {
                new Article
                {
                    Title = "Конец эры глобального CSS",
                    Text = "Все CSS-селекторы живут в глобальной области видимости. Каждому, кто когда-либо имел дело с CSS, приходилось мириться с этой глобальной особенностью. Модель, некогда созданную для стилизации академических документов, сейчас едва ли можно назвать удобным инструментом для создания современных веб-приложений. Абсолютно каждый селектор потенциально может вступить в борьбу с другим селектором или стилизовать «посторонний» элемент. В этой «глобальной» борьбе селектор может даже полностью проиграть, в итоге не применив к странице ни одного из своих правил. Каждый раз модифицируя css-файл, необходимо хорошо подумать о глобальной среде, в которой будут существовать наши стили. Ни одна другая технология веб-разработки не требует столько усилий только для того, чтобы обеспечить коду минимальный уровень поддерживаемости. Так не должно быть. Пора оставить позади эру глобальных стилей. Наступило время закрытого CSS.",
                    Tags = new List<Tag>()
                    {
                        tags[4], tags[5], tags[6],
                        tags[8], tags[9], tags[10]
                    },
                    ClientProfile = user1Profile,
                    TimeCreated = currentTime,
                    TimeEdited = currentTime,
                    Feedbacks = new List<Feedback>()
                    {
                        new Feedback()
                        {
                            ClientProfile = user2Profile,
                            Rating = FeedbackRating.Three,
                            Text = "Неплохо, но я бы мог поспорить с этим"
                        }
                    }
                },

                new Article
                {
                    Title = "Сравнение строк в C# (по умолчанию)",
                    Text = "Часто бывает, что мы соединяем 2 коллекции или группируем коллекцию при помощи LINQ to Objects. При этом происходит сравнение ключей, выбранных для группировки или связывания. К счастью, стоимость этих операций равна O(n). Но в случае больших коллекций нам важна эффективность самого сравнения. Если в качестве ключей выбраны строки, то какая из реализаций сравнения будет использована по умолчанию, подходит ли эта реализация для ваших строк и можно ли, указав IEqualityComparer<string> явно, сделать эту операцию быстрее?",
                    Tags = new List<Tag>()
                    {
                        tags[0], tags[13]
                    },
                    ClientProfile = user2Profile,
                    TimeCreated = currentTime,
                    TimeEdited = currentTime,
                }
            };

            foreach (Article article in articles)
            {
                Articles.Create(article);
            }

            #endregion

            await SaveAsync();
        }

        public IBlogManager<Article> Articles
        {
            get
            {
                if (articlesManager == null)
                {
                    articlesManager = new GenericManager<Article>(_context);
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
