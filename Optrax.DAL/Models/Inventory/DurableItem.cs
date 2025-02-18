using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("DurableItems")]
    public class DurableItem : StockItem
    {
        public DurableItem() { }

        public int? MaintenanceInterval { get; set; }
        public string? MaintenanceInvervalUnit { get; set; }

        public DateTimeOffset? LastMaintenanceCheck { get; set; }
    }
}
