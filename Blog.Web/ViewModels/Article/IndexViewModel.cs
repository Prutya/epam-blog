using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.ViewModels.Article
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public DateTime TimeCreated { get; set; }
        public IEnumerable<Tag.IndexViewModel> Tags { get; set; } 

        public string AuthorName { get; set; }
    }
}