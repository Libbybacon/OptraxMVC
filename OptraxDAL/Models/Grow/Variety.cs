using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Varieties", Schema = "Grow")]
    public class Variety : TrackingBaseDetails
    {
        public Variety() { }

        public int SpeciesID { get; set; }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }
}
