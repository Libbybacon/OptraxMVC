namespace OptraxDAL.Models.Inventory
{
    public class InventoryItem
    {
        public InventoryItem() { }

        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public string? Manufacturer { get; set; }

        public int CategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        public string? SKU { get; set; }

        public string? DefaultUOM { get; set; }

        public decimal StockCount { get; set; } = 0;

        public string? StockUOM { get; set; }

        public bool Active { get; set; } = true;

    }
}
