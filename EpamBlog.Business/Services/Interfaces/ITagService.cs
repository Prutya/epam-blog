using EpamBlog.Business.ViewModels.Tag;
using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.Services.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
        IEnumerable<IndexViewModel> GetByArticleId(int articleId);
        Tag GetById();
        void Create(Tag data);
        void Remove(int id);
        void AssignTagToArticle(int tagId, int articleId);
        void Save();
    }
}
