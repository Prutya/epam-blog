using EpamBlog.Business.ViewModels.Article;
using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.Services.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<IndexViewModel> GetAll();
        IEnumerable<IndexViewModel> GetByAuthorId(int authorId);
        IEnumerable<IndexViewModel> GetByTagId(int id);
        DetailsViewModel GetDetails();
        void Create(CreateViewModel data);
        void Remove(int id);
        void Save();
    }
}
