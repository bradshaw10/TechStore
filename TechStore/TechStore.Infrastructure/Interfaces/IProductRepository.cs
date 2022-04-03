using System.Collections.Generic;
using System.Threading.Tasks;
using TechStore.Infrastructure.Models;

namespace TechStore.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByStatus(int status);
        Product GetProduct(string barcode);
        Task<bool> UpdateProducts(Product product);

    }
}