using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    // Key-value pair linked to a definition
    [Table("PlantTraits", Schema = "Grow")]
    public class PlantTrait : TrackingBase
    {
        public PlantTrait() { }

        public PlantTrait(TraitDefinition def)
        {
            DefinitionId = def.Id;
            Definition = def;
        }

        public int DefinitionId { get; set; }

        public string? Value { get; set; } // Stored as string for flexibility

        public TraitDefinition Definition { get; set; } = null!;

        public ICollection<TraitOption> SelectedOptions { get; set; } = []; // Options selected by the user (For multi-selects)
        public ICollection<PlantProfile> Profiles { get; set; } = [];
    }
}
