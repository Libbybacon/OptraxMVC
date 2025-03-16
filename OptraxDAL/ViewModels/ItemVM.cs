namespace OptraxDAL.ViewModels
{
    public class ItemVM
    {
        public string Cat0 { get; set; } = string.Empty;
        public string Cat1 { get; set; } = string.Empty;
        public int ItemID { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? ItemDesc { get; set; } = string.Empty;
        public string? Brand { get; set; } = string.Empty;
        public string? SKU { get; set; } = string.Empty;
        public string? UoM { get; set; } = string.Empty;
        public string? StockType { get; set; } = string.Empty;
    }
}
