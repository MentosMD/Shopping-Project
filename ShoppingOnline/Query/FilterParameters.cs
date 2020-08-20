namespace ShoppingOnline.Query
{
    public class FilterParameters
    {
        public string NameProduct { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
        public string CodeProduct { get; set; }   
    }
}