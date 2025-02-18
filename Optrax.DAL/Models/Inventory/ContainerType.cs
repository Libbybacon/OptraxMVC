using OptraxDAL.Models.Grow;

namespace OptraxDAL.Models.Inventory
{
    public class ContainerType
    {
        public ContainerType() { }

        public int ContainerTypeID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Capacity { get; set; }
        public required string CapacityUnit { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<InventoryItem> InventoryItems { get; set; } = [];
        public virtual ICollection<TransplantEvent>? Transplants { get; set; } = [];
        public virtual ICollection<ContainerLocation> ContainerLocations { get; set; } = [];

    }
}
