using System;
using ShoppingOnline.Models;
using ShoppingOnline.Repository.OrderRepository;

namespace ShoppingOnline.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        public void AddNewOrder(Order newOrder)
        {
            _orderRepository.AddNewEntity(newOrder);
        }

        public void ChangeStatus(int orderId, string status)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null) throw new ArgumentException("Order is not found");
            switch (status)
            {
                case "New": 
                    order.OrderStatus = OrderStatus.New;
                    break;
                case "InProgress":
                    order.OrderStatus = OrderStatus.Inprogress;
                    break;
                case "Closed":
                    order.OrderStatus = OrderStatus.Closed;
                    break;
            }
            _orderRepository.UpdateEntity(order);
        }
    }
}