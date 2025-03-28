using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{

    [Table("Locations", Schema = "Admin")]
    public class BedLocation : Location
    {
        public BedLocation()
        {
            Level = 3;
        }
    }
}
