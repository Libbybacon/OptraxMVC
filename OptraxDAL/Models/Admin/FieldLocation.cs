using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class FieldLocation : AreaLocation
    {
        public FieldLocation()
        {
            Level = 1;
            Width = 0;
            Length = 0;
            LocationType = "Field";
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
