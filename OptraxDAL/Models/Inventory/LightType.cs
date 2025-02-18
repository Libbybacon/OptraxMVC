using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Inventory
{
    public class LightType
    {
        public LightType() { }

        public int ID { get; set; }
        public decimal? PPF { get; set; }  // Photosynthetic Photon Flux (µmol/s).
        public decimal? PPFD { get; set; } // PPFD: Photosynthetic Photon Flux Density (µmol/m²/s).
        [MaxLength(20)]
        public string? BulbType { get; set; }
        [MaxLength(50)]
        public string? ColorSpectrum { get; set; }
        public decimal? CoverageAreaSF { get; set; }
        public int? LifespanHours { get; set; }
        public int? Voltage { get; set; }

        public virtual required ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
