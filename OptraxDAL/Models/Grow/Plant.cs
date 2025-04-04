using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Plants", Schema = "Grow")]
    public class Plant : TrackingBase
    {
        public Plant() { }

        public string PlantType { get; set; } = string.Empty; // Fruit, Vegetable, Flower, Tree
        public string TaxonType { get; set; } = string.Empty; // Species, Variety, Cultivar
        public string? Family { get; set; }
        public string? Genus { get; set; }
        public string? Species { get; set; }

        public string? ScientificName { get; set; } // e.g. Solanum lycopersicum var. cerasiforme
        public string? CommonName { get; set; }     // e.g. Cherry Tomato
        public string? CultivarName { get; set; }   // e.g. 'Sungold'

        public string? CustomName { get; set; } // Filled in by user
        public string? Abbreviation { get; set; } // Filled in by user
        public string? Description { get; set; }

        public int? Parent1Id { get; set; }
        public int? Parent2Id { get; set; }

        public Plant? Parent1 { get; set; }
        public Plant? Parent2 { get; set; }

        public ICollection<Plant> ChildrenP1 { get; set; } = [];
        public ICollection<Plant> ChildrenP2 { get; set; } = [];

        public int? ProfileId { get; set; }
        public PlantProfile? Profile { get; set; }

        public virtual ICollection<Crop> Crops { get; set; } = [];
    }
}
