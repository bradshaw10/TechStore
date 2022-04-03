using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Interfaces;
using TechStore.Infrastructure.Repositories;
using TechStore.Domain.Models;
using TechStore.Infrastructure.Models;

namespace TechStore.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
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

            countMessage = $"Sold Count: {inStockCount}";

            return ProductResponse(countMessage);
        }

        public ProductResponse UpdateProductStatus(string barcode, Status status)
        {
            var product = GetProduct(barcode);
            if (product == null)
                return ProductResponse("Error: Product Does not Exist", false);

            if (product.Status == status)
                return ProductResponse("Nothing to update", false);

            product.Status = status;

            var updateProductStatus = _productRepository.UpdateProducts(product);

            if(!updateProductStatus.Result)
                return ProductResponse("Failed to update", false);


            return ProductResponse("Updated Succsefully");
        }

        public ProductResponse SellProduct(string barcode)
        {
            var product = GetProduct(barcode);
            if (product == null)
                return ProductResponse("Error: Product Does not Exist", false);

            if(product.Status == Status.Damaged)
                return ProductResponse("Error: Can not sell damaged product", false);

            if (product.Status == Status.Sold)
                return ProductResponse("Error: Product out of Stock", false);

            product.Status = Status.Damaged;
            var updateProductStatus = _productRepository.UpdateProducts(product);

            if (!updateProductStatus.Result)
                return ProductResponse("Failed to update", false);

            return ProductResponse("Product Sold");
        }

        public Product GetProduct(string barcode)
        {
            var product = _productRepository.GetProduct(barcode);
            return product;
        }
    } 
}
