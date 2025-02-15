namespace OptraxDAL.Models.Inventory
{
    public class InventoryCategory
    {
        public InventoryCategory() { }
        public required int ID { get; set; }
        public int? ParentID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool Active { get; set; } = true;
    }
}
