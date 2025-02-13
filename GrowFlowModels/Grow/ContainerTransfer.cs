using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Grow
{
    [Table("PlantTransfers", Schema = "Grow")]
    public class ContainerTransfer : PlantTransfer
    {
        public ContainerTransfer() { }

        [ForeignKey("DestinationID")]
        [InverseProperty(nameof(Container.TransfersIn))]
        public required virtual Container ToContainer { get; set; }

        [ForeignKey("OriginID")]
        [InverseProperty(nameof(Container.TransfersOut))]
        public required virtual Container FromContainer { get; set; }
    }
}
