using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BusinessLogicLayer.Infrastructure
{
    public class OperationDetails
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }

        public OperationDetails(bool success, string message, string prop)
        {
            Success = success;
            Message = message;
            Property = prop;
        }
    }
}
