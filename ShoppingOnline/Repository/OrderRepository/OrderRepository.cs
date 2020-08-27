using System.Collections.Generic;
using ShoppingOnline.Context;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository.OrderRepository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppContext context) : base(context)
        {
        }

        public void Add(Order order)
        {
            
        }

        public void ChangeStatus(int id, OrderStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}