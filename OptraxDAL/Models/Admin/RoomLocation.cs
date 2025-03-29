using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class RoomLocation : Location
    {
        public RoomLocation()
        {
            Level = 2;
            HasAddress = false;
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
