namespace ShoppingOnline.Models
{
    public class ProductPicture : BaseEntity
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}