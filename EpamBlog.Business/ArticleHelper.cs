using EpamBlog.DataAccess;
using EpamBlog.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpamBlog.Business
{
    public class ArticleHelper
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        /// <summary>
        /// Get all Articles
        /// </summary>
        /// <returns>Enumeration of all articles</returns>
        public IEnumerable<Article> GetAll()
        {
            return _db.Articles.AsEnumerable();
        }

        // TODO: GENERIC QUERY!

        /// <summary>
        /// Get Article by ID
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns></returns>
        public Article GetById(int id)
        {
            return _db.Articles.FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Adds article to DB.
        /// </summary>
        /// <param name="author">Article data</param>
        /// <returns></returns>
        public async Task<bool> Add(Article article)
        {
            _db.Articles.Add(article);
            return await _db.SaveChangesAsync() == 1;
        }

        /// <summary>
        /// Removes article from Database
        /// </summary>
        /// <param name="id">Article ID</param>
        /// <returns>If the article was deleted</returns>
        public async Task<bool> Remove(int id)
        {
            var article = _db.Articles.FirstOrDefault(o => o.Id == id);
            if (article != null)
            {
                _db.Articles.Remove(article);
                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }

        /// <summary>
        /// Edits article
        /// </summary>
        /// <param name="id">Article ID</param>
        /// <returns>If the article was edited</returns>
        public async Task<bool> Edit(int id, Article newData)
        {
            var article = _db.Articles.FirstOrDefault(o => o.Id == id);
            if (article != null)
            {
                article.DateTime = newData.DateTime;
                article.Title = newData.Title;
                article.Text = newData.Text;

                return await _db.SaveChangesAsync() == 1;
            }
            return false;
        }
    }
}
