using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Varieties", Schema = "Grow")]
    public class Variety : TrackingBase
    {
        public Variety() { }

        public int ID { get; set; }

        public int SpeciesID { get; set; }

    }
}
