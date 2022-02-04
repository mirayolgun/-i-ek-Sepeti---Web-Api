using CicekSepeti.Business.Abstract;
using CicekSepeti.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService iProductService)
        {
            _productService = iProductService;
        }

        // GET: api/<controller>

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByProductId(int id)
        {
            var result = _productService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
