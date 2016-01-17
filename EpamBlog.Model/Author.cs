using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.Model
{
    public class Author : Entity
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}