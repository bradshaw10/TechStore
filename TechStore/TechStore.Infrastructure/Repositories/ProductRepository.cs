using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Infrastructure.Context;
using TechStore.Infrastructure.Interfaces;
using TechStore.Infrastructure.Models;

namespace TechStore.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByStatus(int status)
        {
            return _context.Products.Where(i => (int)i.Status == status).ToList();
        }

        public IEnumerable<Product> GetProduct(string barcode)
        {
            try {
                return _context.Products.Where(i => i.Barcode == barcode);
            }catch(Exception e)
            {
                return null;
            }
        }
        public async Task<bool> UpdateProducts(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return true;

            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
