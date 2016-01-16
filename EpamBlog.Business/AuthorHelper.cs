using EpamBlog.DataAccess;
using EpamBlog.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpamBlog.Business
{
    public class AuthorHelper
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        /// <summary>
        /// Get all Authors
        /// </summary>
        /// <returns>Enumeration of all authors</returns>
        public IEnumerable<Author> GetAll()
        {
            return _db.Authors.AsEnumerable();
        }

        // TODO: GENERIC QUERY!

        /// <summary>
        /// Get Author by ID
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns></returns>
        public Author GetById(int id)
        {
            return _db.Authors.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Adds author to DB.
        /// </summary>
        /// <param name="author">Author data</param>
        /// <returns></returns>
        public async Task<bool> Add(Author author)
        {
            _db.Authors.Add(author);
            return await _db.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Removes author from Database
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <returns>If the author was deleted</returns>
        public async Task<bool> Remove(int id)
        {
            var author = _db.Authors.FirstOrDefault(o => o.Id == id);
            if (author != null)
            {
                _db.Authors.Remove(author);
                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }

        /// <summary>
        /// Edits author
        /// </summary>
        /// <param name="id">Author ID</param>
        /// <returns>If the author was edited</returns>
        public async Task<bool> Edit(int id, Author newData)
        {
            var author = _db.Authors.FirstOrDefault(o => o.Id == id);
            if (author != null)
            {
                author.Name = newData.Name;
                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }
    }
}
