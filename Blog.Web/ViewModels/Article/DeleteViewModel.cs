using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.ViewModels.Article
{
    public class DeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeEdited { get; set; }

        public string AuthorName { get; set; }
    }
}