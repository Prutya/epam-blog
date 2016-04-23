using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.ViewModels.Article
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Author.IndexViewModel Author { get; set; }
        public IEnumerable<Tag.IndexViewModel> Tags { get; set; }
        public IEnumerable<Feedback.IndexViewModel> Feedbacks { get; set; }
    }
}
