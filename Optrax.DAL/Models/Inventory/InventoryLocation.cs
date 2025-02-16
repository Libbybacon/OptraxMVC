using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("InventoryLocation")]
    public abstract class InventoryLocation
    {
        public InventoryLocation() { }

        public int ID { get; set; }
        public int? ParentID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; } = true;

        [ForeignKey("ParentID")]
        public virtual InventoryLocation? Parent { get; set; } = null;

        public virtual List<InventoryLocation> Children { get; set; } = [];

        public virtual ICollection<InventoryStockItem> StockItems { get; set; } = [];
    }

    [Table("InventoryLocation")]
    public class ContainerLocation : InventoryLocation
    {
        public ContainerLocation() { }

        public new required string Description { get; set; }
    }

    [Table("InventoryLocation")]
    public class RoomLocation : InventoryLocation
    {
        public RoomLocation() { }

        public int RoomID { get; set; }
        public required virtual Room Room { get; set; }
    }

    [Table("InventoryLocation")]
    public class BuildingLocation : InventoryLocation
    {
        public BuildingLocation() { }

        public int BuildingID { get; set; }

        public required virtual Building Building { get; set; }
    }

    [Table("InventoryLocation")]
    public class OffsiteLocation : InventoryLocation
    {
        public OffsiteLocation() { }

        public new required string Description { get; set; }
    }

    public enum LocationType
    {
        Container,
        Room,
        Building,
        Outdoor,
        OffSite
    }
}
