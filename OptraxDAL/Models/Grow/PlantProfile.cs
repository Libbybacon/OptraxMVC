using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantProfiles", Schema = "Grow")]
    public class PlantProfile : BaseClass
    {
        public PlantProfile() { }

        public List<PlantTrait> Traits { get; set; } = [];
        public virtual ICollection<Plant> Plants { get; set; } = [];
    }
}
