using GrowFlow.Models.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Crops

{
    [Table("Plants", Schema = "Grow")]
    public class Plant
    {
        public Plant()
        {
            Transfers = [];
        }

        public int PlantID { get; set; }
        public int StrainID { get; set; }
        public string? GrowthPhase { get; set; }
        public int? RoomID { get; set; }
        public int? LightID { get; set; }
        public int? ContainerID { get; set; }

        public required virtual Strain Strain { get; set; }
        public virtual Room? CurrentRoom { get; set; }
        public virtual Light? CurrentLight { get; set; }
        public virtual ContainerType? CurrentContainer { get; set; }

        public virtual ICollection<PlantTransfer> Transfers { get; set; }
    }
}
