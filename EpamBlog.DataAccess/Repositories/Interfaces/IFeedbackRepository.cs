using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        IEnumerable<Feedback> GetByAuthorId(int authorId);
        Feedback GetById(int id);
        void Create(Feedback data);
        void Remove(int id);
        void Save();
    }
}
