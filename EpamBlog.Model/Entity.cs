using System.ComponentModel.DataAnnotations;

namespace EpamBlog.Model
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
