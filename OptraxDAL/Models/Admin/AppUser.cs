using Microsoft.AspNetCore.Identity;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("AspNetUsers", Schema = "Identity")]
    public class AppUser : IdentityUser
    {
        public AppUser() { }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public virtual ICollection<PlantEvent> PlantEvents { get; set; } = [];
        public virtual ICollection<InventoryTransfer> InventoryTransfers { get; set; } = [];


        public string FullName => $"{FirstName} {LastName}";

        public string DisplayName => $"{LastName}, {FirstName}";

    }
}
