using System.ComponentModel.DataAnnotations;

namespace Blog.DataAccessLayer.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
