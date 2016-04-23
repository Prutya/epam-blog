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
        private readonly BlogDbContext _db;

        public ClientManager(BlogDbContext context)
        {
            _db = context;
        }

        public void Create(ClientProfile item)
        {
            _db.ClientProfiles.Add(item);
            _db.SaveChanges();
        }

        public ClientProfile Get(string id)
        {
            return _db.ClientProfiles.Find(id);
        }

        #region Dispose pattern
        public void Dispose () => _db.Dispose();
        #endregion
    }
}
