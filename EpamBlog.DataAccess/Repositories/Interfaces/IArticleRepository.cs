using EpamBlog.DataAccess.Models;
using System.Collections.Generic;

namespace EpamBlog.DataAccess.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        IEnumerable<Article> GetByAuthorId(int authorId);
        IEnumerable<Article> GetByTagId(int tagId);
        Article GetById(int id);
        void Create(Article data);
        void Delete(int id);
        void Save();
    }
}
