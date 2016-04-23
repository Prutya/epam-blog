using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamBlog.DataAccess.Models
{
    public class Tag : Entity
    {
        public string Text { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
