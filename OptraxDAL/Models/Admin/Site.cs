using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Site : AddressLocation
    {
        public Site()
        {
            LocationType = "Site";
        }

        public Site(int addressID, int? businessID)
        {
            LocationType = "Site";
            AddressID = addressID;
            BusinessID = businessID;
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
