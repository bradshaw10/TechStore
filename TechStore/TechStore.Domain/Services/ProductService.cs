using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Domain.Interfaces;
using TechStore.Infrastructure.Repositories;

namespace TechStore.Domain.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
