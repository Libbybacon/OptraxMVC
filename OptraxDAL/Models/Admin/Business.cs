using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Businesses")]
    public class Business
    {
        public Business() { }
        public int ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? BusinessType { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public virtual List<InventoryLocation>? Locations { get; set; } = [];

        public virtual List<Address> Addresses { get; set; } = [];
    }
    public enum BusinessTypes
    {
        Source,
        Retailer,
        Wholesaler,
        Distributor,
    }


    //[Table("Businesses")]
    //public class Distributor : Business
    //{
    //    public Distributor() { }
    //}

    //[Table("Businesses")]
    //public class Retailer : Business
    //{
    //    public Retailer() { }
    //}

    //[Table("Businesses")]
    //public class Source : Business
    //{
    //    public Source() { }
    //}
}
