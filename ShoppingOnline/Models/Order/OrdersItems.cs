namespace ShoppingOnline.Models
{
    public class OrdersItems : BaseEntity
    {
        public int OrderRef { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public int ProductRef { get; set; }
        public Product Product { get; set; }
    }
}