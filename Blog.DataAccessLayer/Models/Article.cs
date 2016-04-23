using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DataAccessLayer.Models
{
    public class Article : Entity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(3000)]
        public string Text { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeCreated { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeEdited { get; set; }
        [Required]
        public string ClientProfileId { get; set; }

        [NotMapped]
        public string PreviewText
        {
            get
            {
                return Text == null ? Text :
                    Text.Length > 200 ? Text.Substring(0, 200) :
                    Text;
            }
        }

        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
