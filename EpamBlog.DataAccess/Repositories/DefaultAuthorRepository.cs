using EpamBlog.DataAccess.Models;
using EpamBlog.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EpamBlog.DataAccess.Repositories
{
    public class DefaultAuthorRepository : IAuthorRepository
    {
        private readonly BlogDbContext _db;

        public DefaultAuthorRepository()
        {
            _db = new BlogDbContext();
        }
        public DefaultAuthorRepository(BlogDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _db.Authors.AsEnumerable();
        }

        public Author GetById(int id)
        {
            return _db.Authors.FirstOrDefault(o => o.Id == id);
        }

        public void Create(Author data)
        {
            _db.Authors.Add(data);
        }

        public void Delete(int id)
        {
            Author author = GetById(id);
            _db.Authors.Remove(author);
        }

        public void Save() => _db.SaveChanges();
    }
}
