using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Infrastructure.Models;

namespace TechStore.Infrastructure.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions options): base(options) { }
    
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
