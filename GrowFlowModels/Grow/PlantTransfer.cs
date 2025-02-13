using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Grow
{
    [Table("PlantTransfers", Schema = "Grow")]
    public abstract class PlantTransfer : TransferBase
    {
        [ForeignKey(name:"Plant")]
        public required int PlantID { get; set; }

        
        public required virtual Plant Plant { get; set; }
    }
}
