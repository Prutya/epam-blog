using EpamBlog.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamBlog.DataAccess.Models;
using EpamBlog.DataAccess;
using EpamBlog.DataAccess.Repositories;
using EpamBlog.DataAccess.Repositories.Interfaces;
using EpamBlog.Business.ViewModels.Article;

namespace EpamBlog.Business.Services
{
    public class DefaultArticleService : IArticleService
    {
        private readonly IArticleRepository _repo;

        public DefaultArticleService()
        {
            _repo = new DefaultArticleRepository(new BlogDbContext());
        }
        public DefaultArticleService(IArticleRepository repo)
        {
            _repo = repo;
        }

        public void Create(CreateViewModel data)
        {
            var creationDate = DateTime.Now;
            var article = new Article()
            {
                AuthorId = data.AuthorId,
                Text = data.Text,
                Title = data.Title,
                TimeCreated = creationDate,
                TimeEdited = creationDate,
            };
            _repo.Create(article);
        }
        public IEnumerable<IndexViewModel> GetAll()
        {
            var articles = _repo.GetAll();
            var indexViewArticles = new List<IndexViewModel>();
            foreach (var article in articles)
            {
                indexViewArticles.Add(new IndexViewModel()
                {
                    Title = article.Title,
                    PreviewText = article.Text.Take(200) + "...",
                    TimeEdited = article.TimeEdited
                });
            }
            return indexViewArticles;
        }
        public IEnumerable<IndexViewModel> GetByAuthorId(int authorId)
        {
            var articles = _repo.GetByAuthorId(authorId);
            var indexViewArticles = new List<IndexViewModel>();
            foreach (var article in articles)
            {
                indexViewArticles.Add(new IndexViewModel()
                {
                    Title = article.Title,
                    PreviewText = article.Text.Take(200) + "...",
                    TimeEdited = article.TimeEdited
                });
            }
            return indexViewArticles;
        }

        public DetailsViewModel GetDetails(int id)
        {
            var article = _repo.GetById(id);
            
        }

        public IEnumerable<IndexViewModel> GetByTagId(int tagId)
        {
            var articles = _repo.GetByTagId(tagId);
            var indexViewArticles = new List<IndexViewModel>();
            foreach(var article in articles)
            {
                indexViewArticles.Add(new IndexViewModel()
                {
                    Title = article.Title,
                    PreviewText = article.Text.Take(200) + "...",
                    TimeEdited = article.TimeEdited
                });
            }
            return indexViewArticles;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        DetailsViewModel IArticleService.GetDetails()
        {
            throw new NotImplementedException();
        }
    }
}
