using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Web.Models.Article
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    }
}