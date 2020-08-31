namespace ShoppingOnline.Models
{
    public class AvatarProfile : BaseEntity
    {
       public string Name { get; set; } 
       public string Extension { get; set; }
       public int ProfileRef { get; set; }
       public Profile Profile { get; set; }
    }
}