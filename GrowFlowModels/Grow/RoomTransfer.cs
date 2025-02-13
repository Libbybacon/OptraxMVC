using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Grow
{
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
}
