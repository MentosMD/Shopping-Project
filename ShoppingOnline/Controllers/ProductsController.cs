using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Query;
using ShoppingOnline.Services;
using ShoppingOnline.Services.ProductService;
using ShoppingOnline.Services.ProfileService;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProfileService _profileService;

        public ProductsController(IProductService productService, IProfileService profileService)
        {
            _productService = productService;
            _profileService = profileService;
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
        [Route("rating/add")]
        [HttpPost]
        public IActionResult RatingProduct([FromBody] RatingViewModel ratingViewModel)
        {
            var userId = HttpContext.User.Identity.Name;
            int score = ratingViewModel.Score;
            if (score > 5)
            {
                score = 5;
            }
            var getProduct = _productService.GetById(ratingViewModel.ProductId);
            var getProfile = _profileService.GetById(int.Parse(userId));
            var getRating = _productService.GetRatingById(getProduct.ID, getProfile.ID);
            if (getProduct == null) throw new ArgumentNullException("Product is not found");
            if (getProfile == null) throw new ArgumentNullException("User is not found");
            if (getRating != null) return BadRequest("You have voted!");
            Rating rating = new Rating();
            rating.Score = score;
            rating.Product = getProduct;
            rating.Profile = getProfile;
            _productService.AddRating(rating);
            return Ok("Thanks for your rating");
        }
    }
}