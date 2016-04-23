using System.ComponentModel.DataAnnotations;

namespace EpamBlog.DataAccess.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
