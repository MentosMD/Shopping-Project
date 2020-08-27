using System;
using System.Collections.Generic;

namespace ShoppingOnline.Models
{
    public class Order : BaseEntity
    {
        public OrderStatus OrderStatus { get; set; }
        public double TotalSum { get; set; }
        public Profile Profile { get; set; }
        public int ProfileRef { get; set; }
        public ICollection<OrdersItems> OrdersItems { get; set; }
    }
}