using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class RowLocation : AreaLocation
    {
        public RowLocation()
        {
            Level = 2;
            Width = 0;
            Length = 0;
            LocationType = "Row";
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

}
