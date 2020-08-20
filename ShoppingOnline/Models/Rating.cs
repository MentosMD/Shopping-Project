namespace ShoppingOnline.Models
{
    public class Rating : BaseEntity
    {
        public int Score { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}