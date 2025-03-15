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

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; } 

        [MaxLength(450)]
        [ForeignKey("User")]
        public string UserID { get; set; } = string.Empty;

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


        public virtual AppUser? User { get; set; }
        public virtual StockItem? StockItem { get; set; }
        public virtual TransferApproval? Approval { get; set; }
        public virtual TransferEvent? PlantTransfer { get; set; }


        [InverseProperty(nameof(InventoryLocation.TransfersOut))]
        public virtual InventoryLocation? Origin { get; set; }

        [InverseProperty(nameof(InventoryLocation.TransfersIn))]
        public virtual InventoryLocation? Destination { get; set; }


        [NotMapped]
        public string EncryptedID
        {
            get => AesEncryptionHelper.Encrypt(UserID);
            set => UserID = AesEncryptionHelper.Decrypt(value);
        }
    }
}
