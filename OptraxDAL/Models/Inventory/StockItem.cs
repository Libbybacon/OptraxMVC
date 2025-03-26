using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("StockItems", Schema = "Inventory")]
    public abstract class StockItem : TrackingBaseDetails
    {
        public StockItem() { }

        public int ResourceID { get; set; }

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

        public virtual Resource? Resource { get; set; }
        public virtual ICollection<Location> Locations { get; set; } = [];
        public virtual ICollection<InventoryTransfer> Transfers { get; set; } = [];
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = [];
    }


}
