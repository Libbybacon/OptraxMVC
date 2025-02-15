using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    public class Plant
    {
        public Plant(){}

        public int PlantID { get; set; }
        public int StrainID { get; set; }
        public int? ParentID { get; set; }
        public required string StartType { get; set; }
        public bool IsMother { get; set; } = false;
        public string? GrowthPhase { get; set; }
        public int? RoomID { get; set; }
        public int? LightID { get; set; }
        public int? ContainerID { get; set; }

        public required virtual Strain Strain { get; set; }
        public virtual Room? CurrentRoom { get; set; }
        public virtual Light? CurrentLight { get; set; }
        public virtual ContainerType? CurrentContainer { get; set; }

        public virtual ICollection<PlantAction> Actions { get; set; } = [];

        public virtual ICollection<PlantTransfer> Transfers { get; set; } = [];
    }

    public enum GrowthPhases
    {
        Seedling,
        Vegetative,
        Flowering,
        PreHarvest
    }
}
