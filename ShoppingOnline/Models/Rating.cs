namespace ShoppingOnline.Models
{
    public class Rating : BaseEntity
    {
        public int Score { get; set; }
        public int ProfileRef { get; set; }
        public Profile Profile { get; set; }
        public int ProductRef { get; set; }
        public Product Product { get; set; }
    }
}