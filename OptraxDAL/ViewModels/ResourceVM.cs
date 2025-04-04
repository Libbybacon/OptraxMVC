namespace OptraxDAL.ViewModels
{
    public class ResourceVM
    {
        public string Cat0 { get; set; } = string.Empty;
        public string Cat1 { get; set; } = string.Empty;
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = string.Empty;
        public string? ResourceDesc { get; set; } = string.Empty;
        public string? Brand { get; set; } = string.Empty;
        public string? SKU { get; set; } = string.Empty;
        public string? UoM { get; set; } = string.Empty;
        public string? StockType { get; set; } = string.Empty;
    }
}
