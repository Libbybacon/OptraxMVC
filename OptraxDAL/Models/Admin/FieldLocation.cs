using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class FieldLocation : Location
    {
        public FieldLocation()
        {
            Level = 1;
            LocationType = "Field";
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
