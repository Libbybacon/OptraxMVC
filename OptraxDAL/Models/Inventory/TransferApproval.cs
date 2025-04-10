using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("TransferApprovals", Schema = "Inventory")]
    public class TransferApproval
    {
        public int Id { get; set; }

        [ForeignKey("Transfer")]
        public int TransferId { get; set; }

        public DateTimeOffset ApprovalDate { get; set; }

        [Required]
        [MaxLength(450)]
        [ForeignKey("Manager")]
        [Display(Name = "Approving Manager")]
        public string ManagerId { get; set; } = string.Empty;

        public string? Notes { get; set; }

        public virtual required AppUser Manager { get; set; }
        public virtual required InventoryTransfer Transfer { get; set; }
    }
}
