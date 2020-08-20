namespace ShoppingOnline.Models
{
    public class ProductDetail : BaseEntity
    {
        public string DeviceType { get; set; }
        public string OperatingSystem { get; set; }
        public string DisplayDiagonal { get; set; }
        public string DisplayResolution { get; set; }
        public string ScreenMatrixType { get; set; }
        public string RearCamera { get; set; }
        public string SecondChamber { get; set; }
        public string AccumulatorBattery { get; set; }
        public string CPU { get; set; }
        public bool IsWiFi { get; set; }
        public bool IsMemoryCardSupport { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}