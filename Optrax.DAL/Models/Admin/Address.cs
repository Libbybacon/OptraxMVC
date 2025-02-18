using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Admin
{

    public class Address
    {
        public Address() { }

        [Key]
        public int ID { get; set; }
        public required string Address1 { get; set; }
        public string? Address2 { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }

        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
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
