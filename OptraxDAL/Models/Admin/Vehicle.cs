using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Vehicle : Location
    {
        public Vehicle()
        {
            LocationType = "Vehicle";
        }
    }
}
