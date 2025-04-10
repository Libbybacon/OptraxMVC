using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("TraitOptions", Schema = "Grow")]
    public class TraitOption : TrackingBase
    {
        public int DefinitionId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Notes { get; set; }

        public TraitDefinition Definition { get; set; } = null!;

        public ICollection<PlantTrait> Traits { get; set; } = [];
    }
}
