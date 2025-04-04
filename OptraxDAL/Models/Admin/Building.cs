using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Building : AddressLocation
    {
        public Building()
        {
            LocationType = "Building";
        }
        //public BuildingLocation(int addressId, int? businessId)
        //{
        //    Level = 1;
        //    HasAddress = true;
        //    AddressId = addressId;
        //    BusinessId = businessId;
        //}
    }
}
