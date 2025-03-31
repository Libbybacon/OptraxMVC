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
            Tabs = ["Plantings"];
        }

        public virtual ICollection<Planting>? Plantings { get; set; } = [];
        public virtual ICollection<PlantingPattern>? PlantingPatterns { get; set; } = [];

    }
}
