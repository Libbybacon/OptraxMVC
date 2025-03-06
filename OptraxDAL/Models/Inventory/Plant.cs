using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Plants")]
    public class Plant : StockItem
    {
        public Plant() { }

        [Required]
        [MaxLength(50)]
        public string TrackingID { get; set; } = "";
        
        [Required]
        public int StrainID { get; set; } = 0;
        
        public int? ParentID { get; set; }
        
        [Required]
        public bool IsMother { get; set; } = false;

        [Required]
        public string StartType { get; set; } = "Clone";
        
        [Required]
        [MaxLength(10)]
        [Display(Name="Growth Phase")]
        public string StartPhase { get; set; } = "Seed";

        public int? CropID { get; set; }

        public virtual Strain Strain { get; set; } = new();
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
