using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Consumabls", Schema = "Inventory")]
    public class Consumable : StockItem
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

    }
}
