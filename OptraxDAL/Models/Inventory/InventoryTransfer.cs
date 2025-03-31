using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Transfers", Schema = "Inventory")]
    public class InventoryTransfer : TrackingBaseDetails
    {
        public InventoryTransfer() { }

        public InventoryTransfer(bool needsApproval)
        {
            NeedsApproval = needsApproval;
        }

        public int StockItemID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; }


        [Required]
        [Display(Name = "Origin")]
        public int OriginID { get; set; }

        [Required]
        [Display(Name = "Destination")]
        public int DestinationID { get; set; }

        [Display(Name = "Unit Count")]
        public decimal UnitCount { get; set; } = 1;

        [MaxLength(20)]
        [Display(Name = "Unit UoM")]
        public string? UnitUoM { get; set; }

        [Display(Name = "Is Partial Transfer?")]
        public bool IsPartial { get; set; } = false;

        public string Status { get; set; } = "Initiated";

        public string? Notes { get; set; }

        [Display(Name = "Needs Approval")]
        public bool NeedsApproval { get; set; } = false;
        public int? ApprovalID { get; set; }

        public virtual StockItem? StockItem { get; set; }
        public virtual TransferApproval? Approval { get; set; }
        public virtual TransferEvent? PlantTransfer { get; set; }


        [InverseProperty(nameof(Location.TransfersOut))]
        public virtual Location? Origin { get; set; }

        [InverseProperty(nameof(Location.TransfersIn))]
        public virtual Location? Destination { get; set; }


        public InventoryTransfer NewTransfer()
        {
            return new InventoryTransfer()
            {
                Date = Date,
                UserID = UserID,
                OriginID = OriginID,
                DestinationID = DestinationID,
                UnitCount = UnitCount,
                UnitUoM = UnitUoM,
                IsPartial = IsPartial,
                Status = Status,
                Notes = Notes,
                NeedsApproval = NeedsApproval,
                StockItemID = StockItemID,
            };
        }

        public InventoryTransfer NewTransfer(Plant plant)
        {
            var newTransfer = NewTransfer();
            newTransfer.StockItem = plant;
            return newTransfer;
        }
    }
}
