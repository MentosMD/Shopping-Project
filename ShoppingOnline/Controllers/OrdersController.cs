using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/orders")]
    public class OrdersController : Controller
    {
        [Authorize(Roles = "USER")]
        [Route("/checkout")]
        public IActionResult Checkout()
        {
            return Ok();
        }

        [Authorize(Roles = "USER")]
        [Route("/status")]
        public IActionResult StatusOrder()
        {
            return Ok();
        } 
    }
}