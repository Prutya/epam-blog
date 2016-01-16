using EpamBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private BlogDbContext _context;

        private GenericRepository<Author> authorRepository { get; set; }
        private GenericRepository<Article> articleRepository { get; set; }
        private GenericRepository<Feedback> feedbackRepository { get; set; }

        public UnitOfWork()
        {
            _context = new BlogDbContext();
        }
        public UnitOfWork(BlogDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Author> AuthorRepository
        {
            get
            {
                if (authorRepository == null)
                {
                    authorRepository = new GenericRepository<Author>(_context);
                }
                return authorRepository;
            }
        }
        public GenericRepository<Article> ArticleRepository
        {
            get
            {
                if(articleRepository == null)
                {
                    articleRepository = new GenericRepository<Article>(_context);
                }
                return articleRepository;
            }
        }
        public GenericRepository<Feedback> FeedbackRepository
        {
            get
            {
                if(feedbackRepository == null)
                {
                    feedbackRepository = new GenericRepository<Feedback>(_context);
                }
                return feedbackRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
