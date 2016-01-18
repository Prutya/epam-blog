using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamBlog.Web.Models.Author
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }
    }
}