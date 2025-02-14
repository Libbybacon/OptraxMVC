using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models
{
    public abstract class TransferBase 
    {
        public required int ID { get; set; }

        public required DateTimeOffset Date { get; set; }

        public required int OriginID { get; set; }

        public required int DestinationID { get; set; }

        public required int UserID { get; set; }

        public string? Notes { get; set; }
    }
}
