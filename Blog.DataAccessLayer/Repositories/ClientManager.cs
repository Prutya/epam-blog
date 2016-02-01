using Blog.DataAccessLayer.EF;
using Blog.DataAccessLayer.Interfaces;
using Blog.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccessLayer.Repositories
{
    public class ClientManager : IClientManager
    {
        public BlogDbContext Database { get; set; }

        public ClientManager(BlogDbContext context)
        {
            Database = context;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public ClientProfile Get(string id)
        {
            return Database.ClientProfiles.Find(id);
        }

        #region Dispose pattern
        public void Dispose () => Database.Dispose();
        #endregion
    }
}
