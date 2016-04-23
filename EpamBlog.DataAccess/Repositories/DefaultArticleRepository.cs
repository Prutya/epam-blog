using System;
using System.Collections.Generic;
using EpamBlog.DataAccess.Models;
using EpamBlog.DataAccess.Repositories.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace EpamBlog.DataAccess.Repositories
{
    public class DefaultArticleRepository : IArticleRepository
    {
        private readonly BlogDbContext _db;

        public DefaultArticleRepository()
        {
            _db = new BlogDbContext();
        }
        public DefaultArticleRepository(BlogDbContext context)
        {
            _db = context;
        }

        public void Create(Article data)
        {
            _db.Articles.Add(data);
        }

        public void Delete(int id)
        {
            Article article = GetById(id);
            _db.Articles.Remove(article);
        }

        public IEnumerable<Article> GetAll()
        {
            return _db.Articles.AsEnumerable();
        }

        public Article GetById(int id)
        {
            return _db.Articles.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Article> GetByTagId(int tagId)
        {
            var tag = _db.Tags.FirstOrDefault(o => o.Id == tagId);
            return tag == null ? null : tag.Articles.AsEnumerable();
        }

        public void Save() => _db.SaveChanges();
    }
}
