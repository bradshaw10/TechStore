using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Interfaces;
using TechStore.Infrastructure.Repositories;
using TechStore.Domain.Models;
using TechStore.Infrastructure.Models;
using TechStore.Infrastructure.Interfaces;

namespace TechStore.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public ProductResponse CountByStatus()
        {
            var countMessage = string.Empty;

            var inStockCount = _productRepository.GetProductsByStatus((int)Status.inStock).Count();

            countMessage = $"In Stock Count: {inStockCount} \n";

            var damagedCount = _productRepository.GetProductsByStatus((int)Status.Damaged).Count();

            countMessage += $"Damaged Count: {damagedCount} \n";

            var soldCount = _productRepository.GetProductsByStatus((int)Status.Sold).Count();

            countMessage += $"Sold Count: {inStockCount}";

            return new ProductResponse(countMessage);
        }

        public async Task<ProductResponse> UpdateProductStatus(string barcode, Status status)
        {
            var product = GetProduct(barcode);
            if (product == null)
                return new ProductResponse("Error: Product Does not Exist", true);

            if (product.Status == status)
                return new ProductResponse("Nothing to update", true);

            product.Status = status;

            var updateProductStatus = await _productRepository.UpdateProducts(product);

            if(!updateProductStatus)
                return new ProductResponse("Failed to update", true);


            return new ProductResponse("Updated Succsefully");
        }

        public async Task<ProductResponse> SellProduct(string barcode)
        {
            var product = GetProduct(barcode);
            if (product == null)
                return new ProductResponse("Error: Product Does not Exist", true);

            if(product.Status == Status.Damaged)
                return new ProductResponse("Error: Can not sell damaged product", true);

            if (product.Status == Status.Sold)
                return new ProductResponse("Error: Product out of Stock", true);

            product.Status = Status.Sold;
            var updateProductStatus = await _productRepository.UpdateProducts(product);

            if (!updateProductStatus)
                return new ProductResponse("Failed to update", true);

            return new ProductResponse("Product Sold");
        }

        public Product GetProduct(string barcode)
        {
            var product = _productRepository.GetProduct(barcode);
            return product.First();
        }
    } 
}
