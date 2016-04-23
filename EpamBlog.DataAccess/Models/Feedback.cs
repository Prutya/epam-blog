using System.ComponentModel.DataAnnotations;

namespace EpamBlog.DataAccess.Models
{
    public class Feedback : Entity
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public bool IsPositive { get; set; }

        [Required]
        [StringLength(256)]
        public string Text { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
