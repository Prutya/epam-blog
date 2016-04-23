﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Web.Models.Article
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public string PreviewText { get; set; }
        public DateTime TimeEdited { get; set; }
    }
}