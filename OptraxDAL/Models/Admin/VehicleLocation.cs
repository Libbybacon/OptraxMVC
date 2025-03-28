using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class VehicleLocation : Location
    {
        public VehicleLocation()
        {
            Level = 0;
            LocationType = "Vehicle";
        }
    }
}
