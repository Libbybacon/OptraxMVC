using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class SiteLocation : AddressLocation
    {
        public SiteLocation()
        {
            Level = 0;
            HasAddress = true;
            LocationType = "Site";
        }

        public SiteLocation(int addressID, int? businessID)
        {
            Level = 0;
            LocationType = "Site";
            HasAddress = true;
            AddressID = addressID;
            BusinessID = businessID;
        }

        public SiteLocation(Address? address, Business? business)
        {
            Level = 0;
            LocationType = "Site";
            Address = address;
            Business = business;
        }

        public bool IsPrimary { get; set; } = false;
    }
}
