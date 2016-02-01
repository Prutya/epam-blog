using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DataAccessLayer.Models
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [NotMapped]
        public string ShortName
        {
            get
            {
                var result = string.Empty;
                if (FirstName != null && FirstName.Length > 0)
                {
                    result += FirstName[0] + ". ";
                }
                result += LastName;
                return result.Length == 0 ? null : result;
            }
        }

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}