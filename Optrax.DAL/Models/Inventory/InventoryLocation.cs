namespace OptraxDAL.Models.Inventory
{
    public class InventoryLocation
    {
        public InventoryLocation() { }

        public required int ID { get; set; }
        public int? ParentID { get; set; }
        public required string LocationType { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool Active { get; set; } = true;

        public virtual ICollection<InventoryStockItem> StockItems { get; set; } = [];
    }

    public enum LocationType
    {
        Container,
        Room,
        Building,
        Outdoor,
        OffSite
    }
}
