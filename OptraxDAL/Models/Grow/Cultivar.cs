using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Cultivars", Schema = "Grow")]
    public class Cultivar : TrackingBase
    {
        public Cultivar() { }

        public int ID { get; set; }
        public int SpeciesID { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool Patented { get; set; } = false;
        public string? PatentNumber { get; set; }

        public virtual Species Species { get; set; } = null!;
    }
}
