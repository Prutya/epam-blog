using AutoMapper;
using Blog.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<ViewModels.Article.IndexViewModel>>
                (_articleService.GetArticles());
            return View(model);
        }
    }
}