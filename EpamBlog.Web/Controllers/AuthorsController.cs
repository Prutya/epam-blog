using EpamBlog.Business;
using EpamBlog.Web.Models.Author;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EpamBlog.Web.Controllers
{
    public class AuthorsController : Controller
    {
        //private AuthorHelper _authorHelper;

        //public AuthorsController()
        //{
        //    _authorHelper = new AuthorHelper();
        //}
        //public AuthorsController(AuthorHelper authorHelper)
        //{
        //    _authorHelper = authorHelper;
        //}

        // GET: /Authors/Index
        public ActionResult Index()
        {
            return View(_authorHelper
                .GetAll()
                .Select(o => new IndexViewModel()
                {
                    Id = o.Id,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Email = o.Email
                }));
        }

        // GET: /Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            _authorHelper.Create(new Model.Author()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            });
            _authorHelper.Save();

            return RedirectToAction("Index");
        }

        // GET: /Authors/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _authorHelper.GetByID(id.Value);
            if (author != null)
            {
                return View(new EditViewModel()
                {
                    Id = author.Id,
                    Email = author.Email,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST: /Authors/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = _authorHelper.GetByID(model.Id);

                if (author == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }

                author.Email = model.Email;
                author.FirstName = model.FirstName;
                author.LastName = model.LastName;

                //_authorHelper.Update(author);
                _authorHelper.Save();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Authors/Remove/id?
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _authorHelper.GetByID(id.Value);
            if (author != null)
            {
                return View(new IndexViewModel()
                {
                    Email = author.Email,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Id = author.Id
                });
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        // POST /Authors/Remove/id
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            var author = _authorHelper.GetByID(id);
            if (author != null)
            {
                _authorHelper.Delete(author);
                _authorHelper.Save();

                return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}