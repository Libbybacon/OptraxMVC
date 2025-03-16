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

        [Display(Name = "Date Acquired")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? PurchaseDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }

        [MaxLength(50)]
        public string? LotNumber { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
        public bool NeedsTransferApproval { get; set; } = false;

        [Display(Name = "Purchase Price per Item")]
        public decimal? PurchasePrice { get; set; }

        public virtual InventoryItem? InventoryItem { get; set; }
        public virtual ICollection<InventoryLocation> Locations { get; set; } = [];
        public virtual ICollection<InventoryTransfer> Transfers { get; set; } = [];
    }


}
