using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.Model
{
    public class Article : Entity
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(2048)]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
