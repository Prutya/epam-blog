using AutoMapper;
using Blog.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        public ActionResult Index()
        {
            var model = Mapper.Map<IEnumerable<ViewModels.Article.IndexViewModel>>
                (_articleService.GetArticles());
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                return View(Mapper.Map<ViewModels.Article.DeleteViewModel>
                (_articleService.GetArticle(id.Value)));
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}