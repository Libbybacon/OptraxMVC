using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryTransfer
    {
        public InventoryTransfer() { }

        public InventoryTransfer(bool needsApproval)
        {
            NeedsApproval = needsApproval;
        }

        public int ID { get; set; }
        public int StockItemID { get; set; }
        public int OriginID { get; set; }
        public int DestinationID { get; set; }
        public decimal UnitCount { get; set; }

        [MaxLength(20)]
        public required string UnitUOM { get; set; }
        public bool IsPartial { get; set; } = false;

        public bool NeedsApproval { get; set; }
        public int? ApprovingManagerID { get; set; }
        public virtual AppUser? AprrovingManager { get; set; }

        public virtual TransferEvent? PlantTransfer { get; set; }

        public virtual required StockItem StockItem { get; set; }

        [InverseProperty(nameof(InventoryLocation.TransfersOut))]
        public virtual required InventoryLocation Origin { get; set; }

        [InverseProperty(nameof(InventoryLocation.TransfersIn))]
        public virtual required InventoryLocation Destination { get; set; }
    }
}
