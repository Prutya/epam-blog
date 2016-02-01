using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccessLayer.Models
{
    public class Tag : Entity
    {
        [Required]
        [StringLength(50)]
        public string Text { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
