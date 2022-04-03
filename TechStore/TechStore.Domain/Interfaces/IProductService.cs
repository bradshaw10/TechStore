using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Models;
using TechStore.Infrastructure.Models;

namespace TechStore.Domain.Interfaces
{
    public interface IProductService
    {
        ProductResponse CountByStatus();
        Task<ProductResponse> UpdateProductStatus(string barcode, Status status);
        Task<ProductResponse> SellProduct(string barcode);
    }
}
