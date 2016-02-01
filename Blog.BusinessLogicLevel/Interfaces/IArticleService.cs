using Blog.BusinessLogicLayer.DataTransferModel;
using System;
using System.Collections.Generic;

namespace Blog.BusinessLogicLayer.Interfaces
{
    public interface IArticleService : IDisposable
    {
        void CreateArticle(ArticleDTO data);
        ArticleDTO GetArticle(int? id);
        IEnumerable<ArticleDTO> GetArticles();
    }
}
