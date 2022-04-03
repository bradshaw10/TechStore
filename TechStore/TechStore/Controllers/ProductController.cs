using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Domain.Services;
using TechStore.Domain.Models;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProductCountByStatus()
        {
            var productCount = _productService.CountByStatus();

            if (string.IsNullOrEmpty(productCount.ResponseMessage))
                return BadRequest ("Count failed");

            return Ok(productCount.ResponseMessage);
        }
       
    }
}
