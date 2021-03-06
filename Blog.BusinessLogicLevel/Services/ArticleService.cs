﻿using System;
using System.Collections.Generic;
using Blog.BusinessLogicLayer.DataTransferModel;
using Blog.BusinessLogicLayer.Interfaces;
using Blog.DataAccessLayer.Models;
using Blog.DataAccessLayer.Interfaces;
using Blog.BusinessLogicLayer.Infrastructure;
using AutoMapper;

namespace Blog.BusinessLogicLayer.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IBlogUnitOfWork _uow;

        public ArticleService(IBlogUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateArticle(ArticleDTO data)
        {
            DateTime currentTime = DateTime.Now;

            Article article = new Article()
            {
                Title = data.Title,
                Text = data.Text,
                ClientProfileId = data.AuthorId,
                TimeCreated = currentTime,
                TimeEdited = currentTime
            };
            
            foreach(var tag in data.Tags)
            {
                Tag dbtag = _uow.Tags.Get(tag.Id);
                if (dbtag == null)
                {
                    throw new ValidationException("There is no tag with such id.", "TagIds");
                }
                article.Tags.Add(dbtag);
            }

            _uow.Save();
        }
        public void Dispose() => _uow.Dispose();
        public ArticleDTO GetArticle(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Article id not set.", "");
            }
            var article
                = _uow.Articles.Get(id.Value);
            if (article == null)
            {
                throw new ValidationException("Article not found", "");
            }
            return Mapper.Map<ArticleDTO>(article);
        }
        public IEnumerable<ArticleDTO> GetArticles()
        {
            var articles = Mapper.Map<IEnumerable<ArticleDTO>>(_uow.Articles.GetAll());
            return articles;
        }

        public void Delete(int id)
        {
            _uow.Articles.Delete(id);
            _uow.Save();
        }
    }
}
