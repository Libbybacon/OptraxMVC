using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Durables", Schema = "Inventory")]
    public class Durable : StockItem
    {
        public Durable() { }

        public int? MaintenanceInterval { get; set; }
        [MaxLength(20)]
        public string? MaintenanceInvervalUoM { get; set; }

        public DateTimeOffset? LastMaintenanceCheck { get; set; }
    }
}
