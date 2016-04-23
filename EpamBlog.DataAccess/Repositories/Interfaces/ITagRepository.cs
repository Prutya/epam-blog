using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess.Repositories.Interfaces
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        IEnumerable<Tag> GetByArticleId(int articleId);
        Tag GetById(int id);
        void Remove(int id);
        void Create(Tag data);
        void Save();
    }
}
