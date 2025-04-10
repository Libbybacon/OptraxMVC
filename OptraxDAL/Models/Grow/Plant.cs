using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Plants", Schema = "Grow")]
    public class Plant : TrackingBase
    {
        public Plant() { }

        public Plant(List<PlantTrait> traits)
        {
            Profile = new PlantProfile
            {
                Traits = traits
            };
        }

        [Display(Name = "Plant Type")]
        public string PlantType { get; set; } = string.Empty; // Fruit, Vegetable, Herb, Flower, Tree
        [Display(Name = "Taxon")]
        public string TaxonType { get; set; } = string.Empty; // Species, Variety, Cultivar
        [Display(Name = "Is Hybrid")]
        public bool IsHybrid { get; set; } = false;
        public string? Family { get; set; }
        public string? Genus { get; set; }
        public string? Species { get; set; }
        [Display(Name = "Scientific Name")]
        public string? ScientificName { get; set; } // e.g. Solanum lycopersicum var. cerasiforme
        [Display(Name = "Common Name")]
        public string? CommonName { get; set; }     // e.g. Cherry Tomato
        [Display(Name = "Cultivar Name")]
        public string? CultivarName { get; set; }   // e.g. 'Sungold'
        [Display(Name = "Custom Name")]
        public string? CustomName { get; set; } // Filled in by user
        public string? Abbreviation { get; set; } // Filled in by user
        public string? Description { get; set; }

        [Display(Name = "Parent 1")]
        public int? Parent1Id { get; set; }
        public int? Parent2Id { get; set; }

        public Plant? Parent1 { get; set; }
        public Plant? Parent2 { get; set; }

        public ICollection<Plant> ChildrenP1 { get; set; } = [];
        public ICollection<Plant> ChildrenP2 { get; set; } = [];

        public int ProfileId { get; set; }
        public PlantProfile Profile { get; set; } = null!;

        public virtual ICollection<Crop> Crops { get; set; } = [];

        [NotMapped]
        public List<Plant> AllChildren
        {
            get
            {
                return [.. ChildrenP1.ToList().Union([.. ChildrenP2])];
            }
        }
    }
}


