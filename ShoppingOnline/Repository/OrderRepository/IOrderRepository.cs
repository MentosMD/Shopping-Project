using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.OrderRepository
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        void Add(Order order);
        void ChangeStatus(int id, OrderStatus status);
    }
}