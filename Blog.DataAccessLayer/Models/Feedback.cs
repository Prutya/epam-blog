using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccessLayer.Models
{
    public class Feedback : Entity
    {
        [Required]
        [StringLength(200)]
        public string Text { get; set; }
        [Required]
        public FeedbackRating Rating { get; set; }

        [Required]
        public string ClientProfileId { get; set; }
        [Required]
        public int ArticleId { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }
        public virtual Article Article { get; set; }
    }

    public enum FeedbackRating
    {
        NotRated = 0,
        One = 1,
        Two,
        Three,
        Four,
        Five
    }
}
