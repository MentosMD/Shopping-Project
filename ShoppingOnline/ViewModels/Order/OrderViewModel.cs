using System.Collections.Generic;
using ShoppingOnline.Models;

namespace ShoppingOnline.ViewModels
{
    public class OrderViewModel
    {
        public double TotalSum { get; set; }
        public ICollection<OrderItemViewModel> OrderItems { get; set; }
    }
}