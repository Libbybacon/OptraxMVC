using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("TraitDefinitions", Schema = "Grow")]
    public class TraitDefinition : TrackingBase
    {
        public TraitDefinition() { }

        public string Key { get; set; } = string.Empty; // e.g. "PlantingDepth"
        public string DisplayName { get; set; } = string.Empty; // e.g. "Planting Depth"
        public string? Description { get; set; }
        public string? Unit { get; set; } // e.g. inches, days, %
        public string DataType { get; set; } = "string"; // string, decimal, int, bool, etc.
        public string? Group { get; set; } // e.g. Growth, Soil, Water
        public bool AlwaysShow { get; set; } = false; // Always show this trait in the UI, even if empty
        public bool IsCustom { get; set; } = false; // User-defined trait

        public ICollection<PlantTrait> Traits { get; set; } = [];
    }
}
