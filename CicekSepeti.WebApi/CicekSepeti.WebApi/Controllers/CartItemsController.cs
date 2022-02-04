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
    public class CartItemsController : ControllerBase
    {
        private IBasketItemService _basketItemService;

        public CartItemsController(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _basketItemService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByProductId(int id)
        {
            var result = _basketItemService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpPost]
        public IActionResult Add(BasketItem cartItem)
        {
            var result = _basketItemService.Add(cartItem);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
