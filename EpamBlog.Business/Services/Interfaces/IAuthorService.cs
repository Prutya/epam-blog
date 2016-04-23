using EpamBlog.Business.ViewModels.Author;
using EpamBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<IndexViewModel> GetAll();
        Author GetDetails(int id);
        void Create(Author data);
        void Remove(int id);
        void Save();
    }
}
