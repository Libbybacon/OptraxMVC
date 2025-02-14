using GrowFlow.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Crops

{
    [Table("PlantTransfers", Schema = "Grow")]
    public abstract class PlantTransfer : TransferBase
    {
        public int PlantID { get; set; }

        public int EventID { get; set; }

        public required virtual PlantAction Action { get; set; }

        public required virtual Plant Plant { get; set; }
    }


    [Table("PlantTransfers", Schema = "Grow")]
    public class RoomTransfer : PlantTransfer
    {
        public RoomTransfer() { }

        [ForeignKey("DestinationID")]
        [InverseProperty(nameof(Room.TransfersIn))]
        public required virtual Room ToRoom { get; set; }

        [ForeignKey("OriginID")]
        [InverseProperty(nameof(Room.TransfersOut))]
        public required virtual Room FromRoom { get; set; }
    }


    [Table("PlantTransfers", Schema = "Grow")]
    public class ContainerTransfer : PlantTransfer
    {
        public ContainerTransfer() { }

        [ForeignKey("DestinationID")]
        [InverseProperty(nameof(ContainerType.TransfersIn))]
        public required virtual ContainerType ToContainer { get; set; }

        [ForeignKey("OriginID")]
        [InverseProperty(nameof(ContainerType.TransfersOut))]
        public required virtual ContainerType FromContainer { get; set; }
    }
}
