using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore.Infrastructure.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Barcode { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public Status Status { get; set; }
        public List<Category> Categories { get; set; }
    }

    public enum Status
    {
        Sold,
        inStock,
        Damaged
    }
}
