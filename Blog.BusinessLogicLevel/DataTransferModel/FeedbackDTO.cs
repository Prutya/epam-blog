﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLogicLayer.DataTransferModel
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string AuthorId { get; set; }
        public int ArticleId { get; set; }
    }
}
