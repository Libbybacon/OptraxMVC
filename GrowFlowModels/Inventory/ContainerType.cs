using GrowFlow.Models.Crops;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.Marshalling;

namespace GrowFlow.Models.Inventory
{
    public class ContainerType
    {
        public ContainerType()
        {
            Plants = [];
            TransfersIn = [];
            TransfersOut = [];
        }

        public int ID { get; set; }

        public required int InventoryItemID { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required decimal Capacity { get; set; }

        public required string CapacityUnit { get; set; }

        public required virtual InventoryItem InventoryItem { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }

        [InverseProperty(nameof(ContainerTransfer.ToContainer))]
        public virtual ICollection<ContainerTransfer> TransfersIn { get; set; }

        [InverseProperty(nameof(ContainerTransfer.FromContainer))]
        public virtual ICollection<ContainerTransfer> TransfersOut { get; set; }
    }
}
