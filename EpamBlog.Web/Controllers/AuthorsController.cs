using EpamBlog.Business;
using EpamBlog.Web.Models.Author;
using System.Linq;
using System.Web.Mvc;

namespace EpamBlog.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private AuthorHelper _authorHelper;

        public AuthorsController()
        {
            _authorHelper = new AuthorHelper();
        }
        public AuthorsController(AuthorHelper authorHelper)
        {
            _authorHelper = authorHelper;
        }

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
    }
}