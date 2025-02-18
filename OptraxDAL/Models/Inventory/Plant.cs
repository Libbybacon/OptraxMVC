using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Plants")]
    public class Plant : StockItem
    {
        public Plant() { }

        [MaxLength(50)]
        public required string TrackingID { get; set; }
        public int StrainID { get; set; }
        public int? ParentID { get; set; }
        public bool IsMother { get; set; } = false;
        [MaxLength(10)]
        public required string StartPhase { get; set; }
        public int? CropID { get; set; }

        public virtual required Strain Strain { get; set; }

        public virtual Crop? Crop { get; set; }
        public virtual Plant? Parent { get; set; }

        public virtual ICollection<Plant> Children { get; set; } = [];
        public virtual ICollection<PlantEvent> PlantEvents { get; set; } = [];

        public enum GrowthPhases
        {
            Seed,
            Seedling,
            Start,
            Veg,
            Flower,
            PreHarvest
        }

        public enum StartTypes
        {
            Seed,
            Start,
            Clone
        }
    }
}
