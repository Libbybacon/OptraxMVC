using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Crops", Schema = "Grow")]
    public class Crop : TrackingBaseDetails
    {
        public Crop() { }

        [Display(Name = "Strain")]
        public int SpeciesID { get; set; }
        public int? VarietyID { get; set; }
        public int? CultivarID { get; set; }

        public virtual Species? Species { get; set; }
        public virtual Variety? Variety { get; set; }
        public virtual Cultivar? Cultivar { get; set; }

        public virtual ICollection<CropBatch> Batches { get; set; } = [];
        public virtual ICollection<Planting> Plantings { get; set; } = [];
    }
}
