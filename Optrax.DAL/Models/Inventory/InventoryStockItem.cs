namespace OptraxDAL.Models.Inventory
{
    public class InventoryStockItem
    {
        public InventoryStockItem() { }

        public  required int ID { get; set; }
        
        public required int InventoryItemID { get; set; }
        
        public int? LocationID { get; set; }

        public string? LotNumber { get; set; }
        
        public string? UOM { get; set; }
        
        public string? Status { get; set; }

        public DateTimeOffset? PurchaseDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }

        public required virtual InventoryItem InventoryItem { get; set; }
        public virtual InventoryLocation? Location { get; set; }
    }
}
