using Microsoft.AspNetCore.Identity;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("AspNetUsers", Schema = "Identity")]
    public class AppUser : IdentityUser
    {
        public AppUser() { }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<PlantEvent>? PlantEvents { get; set; } = [];
        public virtual ICollection<InventoryTransfer>? InventoryTransfers { get; set; } = [];
        public virtual ICollection<TransferApproval>? TransferApprovals { get; set; } = [];
        public virtual ICollection<Map>? Maps { get; set; }
        public virtual ICollection<Location>? Locations { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public string DisplayName => $"{LastName}, {FirstName}";

    }
}
