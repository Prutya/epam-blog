using EpamBlog.DataAccess.Models;
using System.Collections.Generic;

namespace EpamBlog.DataAccess.Repositories.Interfaces
{
    public interface IAuthorRepository
    { 
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Create(Author data);
        void Delete(int id);
        void Save();
    }
}
