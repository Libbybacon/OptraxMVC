using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Businesses")]
    public class Business
    {
        public Business() { }
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public virtual required List<Address> Addresses { get; set; } = [];
        //public virtual required BusinessAddress Address { get; set; }
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
