using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Query;
using ShoppingOnline.Services.ProductService;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [AllowAnonymous]
        [Route("products")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] FilterParameters filter, int page = 1, int size = 3)
        {
            var filtered = _productService.FilterByParameters(filter);
            var pagination = new Pagination<Product>(page, size);
            return Ok(pagination.Paged(filtered));
        }
        
        [Authorize(Roles = Roles.Admin)]
        [Route("/update")]
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.User)]
        [Route("/rating/add")]
        [HttpPost]
        public IActionResult RatingProduct([FromBody] int score)
        {
            return Ok();
        }
    }
}