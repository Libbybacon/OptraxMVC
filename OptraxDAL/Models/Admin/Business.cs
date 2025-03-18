using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Businesses")]
    public class Business : TrackingBase
    {
        public Business() { }
        public int ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string BusinessType { get; set; } = "Grower";

        [MaxLength(250)]
        public string? Description { get; set; }

        public virtual List<Address> Addresses { get; set; } = [];
        public virtual List<SiteLocation>? Sites { get; set; } = [];
        public virtual List<BuildingLocation>? Buildings { get; set; } = [];

    }
    public enum BusinessTypes
    {
        Grower,
        Vendor,
        Customer,
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
