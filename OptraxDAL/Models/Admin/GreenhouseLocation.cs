using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class GreenhouseLocation : AreaLocation
    {
        public GreenhouseLocation()
        {
            Level = 1;
            Width = 0;
            Length = 0;
            LocationType = "Greenhouse";
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
