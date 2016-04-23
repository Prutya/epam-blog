using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.ViewModels.Article
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public DateTime TimeEdited { get; set; }
    }
}
