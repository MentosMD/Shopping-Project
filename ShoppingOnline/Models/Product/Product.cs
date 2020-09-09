using System.Collections.Generic;

namespace ShoppingOnline.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string CodeProduct { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public OrdersItems OrderItems { get; set; }
    }
}