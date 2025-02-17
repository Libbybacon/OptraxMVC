using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryCategory
    {
        public InventoryCategory()
        {
            Active = true;
        }

        public int ID { get; set; }
        public int? ParentID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

        [ForeignKey("ParentID")]
        public virtual InventoryCategory? Parent { get; set; } = null;

        public virtual List<InventoryCategory> Children { get; set; } = [];

        public virtual List<InventoryItem> Items { get; set; } = [];
    }
}
