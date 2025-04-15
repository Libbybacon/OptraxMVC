using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Site : AddressLocation
    {
        public Site()
        {
            LocationType = "Site";

            Address = new() { Name = Name };
        }

        public Site(int addressId, int? businessId)
        {
            LocationType = "Site";
            AddressId = addressId;
            BusinessId = businessId;
        }

        public Site(Address? address, Business? business)
        {
            LocationType = "Site";
            Address = address;
            Business = business;
        }

        public bool IsPrimary { get; set; } = false;

        [NotMapped]
        public bool IsFirst { get; set; } = false;

    }
}
