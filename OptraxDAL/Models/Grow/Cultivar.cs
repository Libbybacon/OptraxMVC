using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Cultivars", Schema = "Grow")]
    public class Cultivar : TrackingBaseDetails
    {
        public Cultivar() { }

        public bool Hybrid { get; set; } = false;
        public string? Genotype { get; set; }
        public string? Phenotype { get; set; }
        public string? BreedingMethod { get; set; }
        public int Generation { get; set; } = 0;
        public bool Patented { get; set; } = false;
        public string? PatentNumber { get; set; }

        //public virtual List<Species> ParentSpecies { get; set; } = [];
        public virtual List<Variety> ParentVarieties { get; set; } = [];
        public virtual List<Cultivar> ParentCultivars { get; set; } = [];

        public virtual ICollection<Crop> Crops { get; set; } = [];
    }
}
