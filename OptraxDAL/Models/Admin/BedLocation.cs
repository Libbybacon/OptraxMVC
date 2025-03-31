using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{

    [Table("Locations", Schema = "Admin")]
    public class BedLocation : AreaLocation
    {
        public BedLocation()
        {
            Level = 3;
            Width = 0;
            Length = 0;
            LocationType = "Bed";
        }
    }
}
