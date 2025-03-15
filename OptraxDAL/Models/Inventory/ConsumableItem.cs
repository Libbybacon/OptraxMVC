using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("ConsumableItems")]
    public class ConsumableItem : StockItem
    {
        [MaxLength(50)]
        public string? Size { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }

        public decimal UnitCount { get; set; }

        [Required]
        [MaxLength(50)]
        [ForeignKey("UnitUoM")]
        public string UoMName { get; set; } = string.Empty;
        public virtual UoM? UnitUoM { get; set; }

        public virtual ICollection<TreatmentEvent> PlantTreatments { get; set; } = [];
    }
}
