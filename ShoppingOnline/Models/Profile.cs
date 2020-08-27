using System.Collections.Generic;

namespace ShoppingOnline.Models
{
    public class Profile : BaseEntity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public int UserRef { get; set;}
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Rating Rating { get; set; }
    }
}