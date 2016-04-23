using EpamBlog.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamBlog.DataAccess.Models;

namespace EpamBlog.DataAccess.Repositories
{
    public class DefaultFeedbackRepository : IFeedbackRepository
    {
        private readonly BlogDbContext _db;

        public DefaultFeedbackRepository()
        {
            _db = new BlogDbContext();
        }
        public DefaultFeedbackRepository(BlogDbContext context)
        {
            _db = context;
        }

        public void Create(Feedback data)
        {
            _db.Feedbacks.Add(data);
        }

        public IEnumerable<Feedback> GetAll()
        {
            return _db.Feedbacks.AsEnumerable();
        }

        public Feedback GetById(int id)
        {
            return _db.Feedbacks.FirstOrDefault(o => o.Id == id);
        }

        public void Remove(int id)
        {
            Feedback feedback = GetById(id);

        }

        public void Save() => _db.SaveChanges();
    }
}
