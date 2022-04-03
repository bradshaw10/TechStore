using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Domain.Models
{
    public class ProductResponse
    {
        public ProductResponse()
        {

        }

        public ProductResponse(string success) : this()
        {

        }

        public ProductResponse(string failure, bool error): this()
        {

        }
    }
}
