using ShoppingOnline.Models;

namespace ShoppingOnline.Services.OrderService
{
    public interface IOrderService
    {
        void AddNewOrder(Order newOrder);
        void ChangeStatus(int orderId, string status);
    }
}