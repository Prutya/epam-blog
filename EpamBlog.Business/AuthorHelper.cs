using EpamBlog.DataAccess;
using EpamBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business
{
    public class AuthorHelper : IDisposable
    {
        private UnitOfWork _uow;

        public AuthorHelper()
        {
            _uow = new UnitOfWork();
        }
        public AuthorHelper(UnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Author> GetAll()
        {
            return _uow.AuthorRepository.Get();
        }
        public Author GetByID(int id)
        {
            return _uow.AuthorRepository.GetByID(id);
        }
        public Author GetWithByIdWithArticles(int id)
        {
            var author = _uow.AuthorRepository.GetByID(id);
            author.Articles = _uow.ArticleRepository.Get(o => o.AuthorId == id).ToList();

            return author;
        }
        public void Create(Author entity)
        {
            _uow.AuthorRepository.Insert(entity);
        }
        public void Delete(int id)
        {
            _uow.AuthorRepository.Delete(id);
        }
        public void Delete(Author entityToDelete)
        {
            _uow.AuthorRepository.Delete(entityToDelete);
        }
        public void Update(Author entityToUpdate)
        {
            _uow.AuthorRepository.Update(entityToUpdate);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
