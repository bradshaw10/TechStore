﻿using System;
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

        public Product GetProduct(int id)
        {
           return (Product)_context.Products.Where(i => i.ID == id);
        }

        public  UpdateProducts(Product product)
        {
           try
           {
             var update = _context.Products.Update(product);
                _context.SaveChanges();

        }
    }
}