using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.Model
{
    public class Author : Entity
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}