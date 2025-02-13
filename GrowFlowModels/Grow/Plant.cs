using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Grow

{
    [Table("Plants", Schema = "Grow")]
    public class Plant
    {
        public Plant()
        {
            Transfers = [];
        }

        public required int PlantID { get; set; }
        
        public required int StrainID { get; set; }
        public required virtual Strain Strain { get; set; }

        public string? GrowthPhase { get; set; }

        public int? RoomID { get; set; }
        public virtual Room? CurrentRoom { get; set; }

        public int? LightID { get; set; }
        public virtual Light? CurrentLight { get; set; }

        public int? ContainerID { get; set; }
        public virtual Container? CurrentContainer { get; set; }

        public virtual ICollection<PlantTransfer> Transfers { get; set; }
    }
}
