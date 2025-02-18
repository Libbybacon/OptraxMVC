using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Inventory
{
    public class ContainerType
    {
        public ContainerType() { }

        public int ContainerTypeID { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public required decimal Capacity { get; set; }
        [MaxLength(20)]
        public required string CapacityUOM { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<InventoryItem> InventoryItems { get; set; } = [];
        public virtual ICollection<TransplantEvent>? Transplants { get; set; } = [];
        public virtual ICollection<ContainerLocation> ContainerLocations { get; set; } = [];

    }
}
