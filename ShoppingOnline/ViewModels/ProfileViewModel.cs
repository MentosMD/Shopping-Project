using Microsoft.AspNetCore.Http;

namespace ShoppingOnline.ViewModels
{
    public class ProfileViewModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public IFormFile Avatar { get; set; }
    }
}