using EpamBlog.DataAccess;
using EpamBlog.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpamBlog.Business
{
    public class FeedbackHelper
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        public IEnumerable<Feedback> GetAll()
        {
            return _db.Feedbacks.AsEnumerable();
        }

        public Feedback GetById(int id)
        {
            return _db.Feedbacks.FirstOrDefault(o => o.Id == id);
        }

        public async Task<bool> Add(Feedback feedback)
        {
            _db.Feedbacks.Add(feedback);
            return await _db.SaveChangesAsync() == 1;
        }

        public async Task<bool> Remove(int id)
        {
            var feedback = _db.Feedbacks.FirstOrDefault(o => o.Id == id);
            if (feedback != null)
            {
                _db.Feedbacks.Remove(feedback);
                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }

        public async Task<bool> Edit(int id, Feedback newData)
        {
            var feedback = _db.Feedbacks.FirstOrDefault(o => o.Id == id);
            if (feedback != null)
            {
                feedback.Email = newData.Email;
                feedback.IsPositive = newData.IsPositive;
                feedback.Name = newData.Name;
                feedback.Text = newData.Text;

                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }
    }
}
