using OptraxDAL.Models.Grow;
using System.Runtime.InteropServices.Marshalling;

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

        public string? SKU { get; set; }

        public string? DefaultUOM { get; set; }

        public decimal StockCount { get; set; } = 0;

        public string? StockUOM { get; set; }

        public bool Active { get; set; } = true;

        public virtual Light? Light { get; set; }

        public virtual Plant? Plant { get; set; }

        public required virtual InventoryCategory Category { get; set; }

        public virtual ICollection<InventoryStockItem> StockItems { get; set; } = [];
    }
}
