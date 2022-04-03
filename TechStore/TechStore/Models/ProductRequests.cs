using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Infrastructure.Models;

namespace TechStore.Models
{
    public class ChangeStatusRequest
    {
        public string Barcode { get; set; }
        public Status Status { get; set; }
    }

    public class SellProductRequest
    {
        public string Barcode { get; set; }
    }
}
