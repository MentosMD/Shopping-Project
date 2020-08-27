using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/orders")]
    public class OrdersController : Controller
    {
        [Authorize(Roles = Roles.User)]
        [Route("/add")]
        public IActionResult Checkout()
        {
            return Ok();
        }

        [Authorize(Roles = Roles.User)]
        [Route("/change-status")]
        public IActionResult StatusOrder()
        {
            return Ok();
        } 
    }
}