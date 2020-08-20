using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Route("/comments")]
    public class CommentsController : Controller
    {
        [AllowAnonymous]
        [Route("/get/{idProduct}")]
        public IActionResult GetAllCommentsProduct(int idProduct)
        {
            return Ok();
        }

        [Authorize(Roles = "USER")]
        [Route("/add/{idProduct}")]
        public IActionResult AddCommentProduct(int idProduct)
        {
            return Ok();
        }
    
        [Route("/update/{idProduct}")]
        public IActionResult UpdateCommentProduct(int idProduct)
        {
            return Ok();
        }
        
        [Authorize(Roles = "USER")]
        [Route("/delete/{idProduct}")]
        public IActionResult DeleteCommentProduct()
        {
            return Ok();
        }
    }
}