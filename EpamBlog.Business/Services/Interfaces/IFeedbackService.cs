using EpamBlog.Business.ViewModels.Feedback;
using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.Services.Interfaces
{
    public interface IFeedbackService
    {
        IEnumerable<IndexViewModel> GetAll();
        IEnumerable<IndexViewModel> GetByArticleId(int articleId);
        void Create(Feedback data);
        void Remove(int id);
        void Save();
    }
}
