using GrowFlow.Models.Crops;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowFlow.Models.Inventory
{
    [Table("Lights", Schema = "Grow")]
    public class Light
    {
        public Light()
        {
            Active = true;
        }

        public int ID { get; set; }

        public int? InventoryStockID { get; set; }
        public decimal? PPF { get; set; }  // Photosynthetic Photon Flux (µmol/s).
        public decimal? PPFD { get; set; } // PPFD: Photosynthetic Photon Flux Density (µmol/m²/s).
        public string? BulbType { get; set; }

        [MaxLength(50)]
        public string? ColorSpectrum { get; set; }
        public decimal? CoverageAreaSF { get; set; }
        public int? LifespanHours { get; set; }

        [MaxLength(100)]
        public string? Manufacturer { get; set; }
        public int? Voltage { get; set; }

        public decimal? Price { get; set; }
        public int? RoomID { get; set; }

        public bool Active { get; set; }

        public virtual Room? Room { get; set; }

        public virtual InventoryStockItem? InventoryStockItem { get; set; }

        public virtual ICollection<Plant>? Plants { get; set; }
    }
}
