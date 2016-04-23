using Blog.BusinessLogicLayer.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLogicLevel.Interfaces
{
    public interface ITagService
    {
        IEnumerable<TagDTO> GetTags();
        TagDTO Get(int id);
    }
}
