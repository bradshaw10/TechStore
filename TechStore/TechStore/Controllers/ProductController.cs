using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechStore.Domain.Services;
using TechStore.Domain.Models;
using TechStore.Models;
using TechStore.Domain.Interfaces;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProductCountByStatus()
        {
            var productCount = _productService.CountByStatus();

            if (string.IsNullOrEmpty(productCount.ResponseMessage))
                return BadRequest("Count failed");

            if (!productCount.Error)
                return BadRequest(productCount.ResponseMessage);

            return Ok(productCount.ResponseMessage);
        }
       
        [HttpPost("ChangeStatus")]
        public IActionResult UpdateProductStatus(ChangeStatusRequest changeStatusRequest)
        {
            var productStatus = _productService.UpdateProductStatus(changeStatusRequest.Barcode, changeStatusRequest.Status);

            if (!productStatus.Error)
                return BadRequest(productStatus.ResponseMessage);

            return Ok(productStatus.ResponseMessage);
        }

        [HttpPost("SellProduct")]
        public IActionResult SellProduct(SellProductRequest sellProductRequest)
        {
            var productStatus = _productService.SellProduct(sellProductRequest.Barcode);

            if (!productStatus.Error)
                return BadRequest(productStatus.ResponseMessage);

            return Ok(productStatus.ResponseMessage);
        }

    }
}
