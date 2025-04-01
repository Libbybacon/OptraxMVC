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
        //public BuildingLocation(int addressID, int? businessID)
        //{
        //    Level = 1;
        //    HasAddress = true;
        //    AddressID = addressID;
        //    BusinessID = businessID;
        //}
    }
}
