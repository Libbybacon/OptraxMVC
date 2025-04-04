using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantingSections", Schema = "Grow")]
    public class PlantingSection : TrackingBaseDetails
    {
        public PlantingSection() { }

        public int PlantingId { get; set; }
        public int? Order { get; set; }
        public int? ParentId { get; set; }
        public int PatternId { get; set; }
        public int? MapObjectId { get; set; }
        public string SectionType { get; set; } = ""; // Field, Row, Bed, Plot


        public virtual Planting Planting { get; set; } = new();
        public virtual PlantingSection? Parent { get; set; }
        public virtual PlantingPattern Pattern { get; set; } = new();
        public virtual MapObject? MapObject { get; set; }

        public virtual ICollection<PlantingSection> Children { get; set; } = [];
    }
}
