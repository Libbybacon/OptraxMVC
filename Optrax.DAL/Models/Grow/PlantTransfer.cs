using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow

{
    [Table("PlantTransfers")]
    public abstract class PlantTransfer : TransferActionBase
    {
        public int PlantID { get; set; }

        [ForeignKey("PlantAction")]
        public int ActionID { get; set; }

        public required virtual TransferAction PlantAction { get; set; }

        public required virtual Plant Plant { get; set; }
    }


    [Table("PlantTransfers")]
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

    [Table("PlantTransfers")]
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

    [Table("PlantTransfers")]
    public class LightTransfer : PlantTransfer
    {
        public LightTransfer() { }

        [ForeignKey("DestinationID")]
        [InverseProperty(nameof(Light.TransfersIn))]
        public required virtual Light ToLight { get; set; }

        [ForeignKey("OriginID")]
        [InverseProperty(nameof(Light.TransfersOut))]
        public required virtual Light FromLight { get; set; }
    }
}
