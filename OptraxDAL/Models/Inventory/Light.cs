using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Lights", Schema = "Inventory")]
    public class Light : StockItem
    {
        public DateTimeOffset? FirstInstallDate { get; set; }
        public DateTimeOffset? LastMaintenanceCheck { get; set; }

        public virtual ICollection<PlantEvent> PlantLightEvents { get; set; } = [];
    }
}
