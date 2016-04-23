using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Business.ViewModels.Article
{
    public class CreateViewModel
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(2048)]
        public string Text { get; set; }

        //public Dictionary<int, bool> Tags { get; set; }
    }
}
