using System;
using System.Collections.Generic;

namespace Blog.BusinessLogicLayer.DataTransferModel
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeEdited { get; set; }
        public string AuthorName { get; set; }

        public IEnumerable<TagDTO> Tags { get; set; }
    }
}
