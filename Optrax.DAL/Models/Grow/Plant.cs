using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    public class Plant
    {
        public Plant() { }

        public int ID { get; set; }
        public int StrainID { get; set; }
        public int? ParentID { get; set; }
        public int InventoryStockItemID { get; set; }
        public int? CropID { get; set; }
        public required string StartType { get; set; }
        public bool IsMother { get; set; } = false;
        public string? GrowthPhase { get; set; }
        public int? RoomID { get; set; }
        public int? LightID { get; set; }
        public int? ContainerID { get; set; }

        public required virtual Strain Strain { get; set; }

        public virtual Plant? Parent { get; set; }
        public virtual Crop? Crop { get; set; }
        public virtual Room? CurrentRoom { get; set; }
        public virtual Light? CurrentLight { get; set; }
        public virtual ContainerType? CurrentContainer { get; set; }
        public required virtual InventoryStockItem InventoryStockItem { get; set; }

        public virtual ICollection<PlantAction> Actions { get; set; } = [];
        public virtual ICollection<PlantTransfer> Transfers { get; set; } = [];

        public InventoryItem GetInventoryItem()
        {
            return InventoryStockItem.InventoryItem;
        }
    }


    public enum GrowthPhases
    {
        Seed,
        Seedling,
        Start,
        Veg,
        Flowering,
        PreHarvest
    }

    public enum StartTypes
    {
        Seed,
        Start,
        Clone
    }
}
