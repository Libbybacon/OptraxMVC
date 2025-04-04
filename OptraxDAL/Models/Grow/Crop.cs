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
        public int PlantId { get; set; }
        public virtual Plant Plant { get; set; } = new();

        public virtual ICollection<CropBatch> Batches { get; set; } = [];
        public virtual ICollection<Planting> Plantings { get; set; } = [];
    }
}
