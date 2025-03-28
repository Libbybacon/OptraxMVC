using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class GreenhouseLocation : Location
    {
        public GreenhouseLocation()
        {
            Level = 1;
            LocationType = "Greenhouse";
        }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
