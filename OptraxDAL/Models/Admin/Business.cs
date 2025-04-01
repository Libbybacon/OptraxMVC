using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Businesses", Schema = "Admin")]
    public class Business : TrackingBaseDetails
    {
        public Business() { }

        [MaxLength(50)]
        public string BusinessType { get; set; } = "Grower";

        public virtual List<Address> Addresses { get; set; } = [];
        public virtual List<Site>? Sites { get; set; } = [];
        public virtual List<Building>? Buildings { get; set; } = [];

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
