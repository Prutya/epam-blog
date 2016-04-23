using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.ViewModels.Article
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(3000)]
        public string Text { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        //[Required]
        //public int[] TagIds { get; set; }
    }
}