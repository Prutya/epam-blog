using EpamBlog.DataAccess.Models;
using EpamBlog.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess.Repositories
{
    public class DefaultTagRepository : ITagRepository
    {
        private readonly BlogDbContext _db;

        public DefaultTagRepository()
        {
            _db = new BlogDbContext();
        }

        public DefaultTagRepository(BlogDbContext context)
        {
            _db = context;
        }

        public void Create(Tag data)
        {
            _db.Tags.Add(data);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _db.Tags.AsEnumerable();
        }

        public IEnumerable<Tag> GetByArticleId(int articleId)
        {
            var article = _db.Articles.FirstOrDefault(o => o.Id == articleId);
            return article == null ? null : article.Tags.AsEnumerable();
        }

        public Tag GetById(int id)
        {
            return _db.Tags.FirstOrDefault(o => o.Id == id);
        }

        public void Remove(int id)
        {
            var tag = GetById(id);
            _db.Tags.Remove(tag);

        }

        public void Save() => _db.SaveChanges();
    }
}
