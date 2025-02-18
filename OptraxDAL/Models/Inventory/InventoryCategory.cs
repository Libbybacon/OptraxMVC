using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryCategory
    {
        public InventoryCategory() { }

        public int ID { get; set; }
        public int? ParentID { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        public bool Active { get; set; } = true;

        public virtual List<InventoryItem> Items { get; set; } = [];
        public virtual InventoryCategory? Parent { get; set; } = null;
        public virtual List<InventoryCategory> Children { get; set; } = [];

    }
}
