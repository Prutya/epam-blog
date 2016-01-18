using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Web.Models.Author
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} {2} ({3})", Id, FirstName, LastName, Email);
        }
    }
}