using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("DurableItems")]
    public class DurableItem : StockItem
    {
        public DurableItem() { }

        public int? MaintenanceInterval { get; set; }
        [MaxLength(20)]
        public string? MaintenanceInvervalUoM { get; set; }

        public DateTimeOffset? LastMaintenanceCheck { get; set; }
    }
}
