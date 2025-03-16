using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Lights")]
    public class Light : StockItem
    {
        public DateTimeOffset? FirstInstallDate { get; set; }
        public DateTimeOffset? LastMaintenanceCheck { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<PlantEvent> PlantLightEvents { get; set; } = [];
    }
}
