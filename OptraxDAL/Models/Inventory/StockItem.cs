using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("StockItems")]
    public abstract class StockItem
    {
        public StockItem() { }

        public int ID { get; set; }
        public int InventoryItemID { get; set; }

        public DateTimeOffset? PurchaseDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }

        [MaxLength(50)]
        public string? LotNumber { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
        public bool NeedsTransferApproval { get; set; } = false;
        public decimal? PurchasePrice { get; set; }

        public virtual required InventoryItem InventoryItem { get; set; }
        public virtual ICollection<InventoryLocation> Locations { get; set; } = [];
        public virtual ICollection<InventoryTransfer> Transfers { get; set; } = [];
    }

}
