using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Services.OrderService;
using ShoppingOnline.Validations;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [Authorize(Roles = Roles.User)]
        [Route("add")]
        [HttpPost]
        public IActionResult Checkout([FromBody] OrderViewModel order)
        {
            var user = int.Parse(HttpContext.User.Identity.Name);
            var validator = new OrderModelValidator();
            var validationResult = validator.Validate(order);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            List<OrdersItems> orderItems = new List<OrdersItems>();
            foreach (var item in order.OrderItems)
            {
                orderItems.Add(new OrdersItems()
                {
                    Quantity = item.Quantity,
                    ProductRef = item.ProductInt
                });
            }
            var newOrder = new Order()
            {
                TotalSum = order.TotalSum,
                OrderStatus = OrderStatus.New,
                OrdersItems = orderItems,
                ProfileRef = int.Parse(HttpContext.User.Identity.Name)
            }; 
            _orderService.AddNewOrder(newOrder);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "Added"
            };
            return Ok(response);
        }

        [Authorize(Roles = Roles.Admin)]
        [Route("change-status")]
        [HttpPatch]
        public IActionResult StatusOrder([FromBody] ChangeStatusViewModel status)
        {
            var validator = new ChangeStatusValidator();
            var validationResult = validator.Validate(status);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            _orderService.ChangeStatus(status.IdOrder, status.Status);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "Done!"
            };
            return Ok(response);
        } 
    }
}