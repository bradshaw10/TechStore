using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Domain.Models
{
    public class ProductResponse
    {
        public string ResponseMessage;
        public bool Error;
        public ProductResponse() : base()
        {

        }

        public ProductResponse(string success)
        {
            ResponseMessage = success;
        }

        public ProductResponse(string failure, bool error)
        {
            ResponseMessage = failure;
            Error = error;
        }
    }
}
