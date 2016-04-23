using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.ViewModels.Author
{
    public class DetailsViewModel : IndexViewModel
    {
        public IEnumerable<Article.IndexViewModel> Articles { get; set; }
    }
}
