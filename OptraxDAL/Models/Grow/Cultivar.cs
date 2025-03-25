using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Cultivars", Schema = "Grow")]
    public class Cultivar : TrackingBaseDetails
    {
        public Cultivar() { }
        public int SpeciesID { get; set; }

        public bool Patented { get; set; } = false;
        public string? PatentNumber { get; set; }

        public virtual Species Species { get; set; } = null!;
    }
}
