using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Admin
{

    public class Address
    {
        public Address() { }

        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public required string Address1 { get; set; }
        [MaxLength(100)]
        public string? Address2 { get; set; }
        [MaxLength(50)]
        public required string City { get; set; }
        [MaxLength(10)]
        public required string State { get; set; }
        [MaxLength(20)]
        public required string ZipCode { get; set; }

        [MaxLength(100)]
        public string? ContactName { get; set; }
        [MaxLength(20)]
        public string? ContactPhone { get; set; }
        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        public int? BusinessID { get; set; }
        public int? BuildingID { get; set; }

        public virtual Business? Business { get; set; }

        public virtual BuildingLocation? Building { get; set; }
    }

    //public class BuildingAddress : Address
    //{
    //    public int InventoryLocationID { get; set; }
    //    public virtual required BuildingLocation BuildingLocation { get; set; }
    //}

    //public class BusinessAddress : Address
    //{
    //    public int BusinessID { get; set; }
    //}
}
