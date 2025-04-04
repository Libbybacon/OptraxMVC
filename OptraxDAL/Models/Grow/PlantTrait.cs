using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    // Key-value pair linked to a definition
    [Table("PlantTraits", Schema = "Grow")]
    public class PlantTrait : TrackingBase
    {
        public PlantTrait() { }

        public string Value { get; set; } = string.Empty; // Stored as string for flexibility

        public int DefinitionId { get; set; }
        public TraitDefinition Definition { get; set; } = null!;

        public int ProfileId { get; set; }
        public ICollection<PlantProfile> Profiles { get; set; } = [];


    }
}
