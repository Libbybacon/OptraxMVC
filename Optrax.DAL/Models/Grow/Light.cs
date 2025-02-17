using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{    
    public class Light
    {
        public Light() { }

        public int ID { get; set; }
        public int? InventoryStockID { get; set; }
        public int? RoomID { get; set; }
        public bool Active { get; set; } = true;

        public decimal? PPF { get; set; }  // Photosynthetic Photon Flux (µmol/s).
        public decimal? PPFD { get; set; } // PPFD: Photosynthetic Photon Flux Density (µmol/m²/s).
        public string? BulbType { get; set; }
        public string? ColorSpectrum { get; set; }
        public decimal? CoverageAreaSF { get; set; }
        public int? LifespanHours { get; set; }
        public int? Voltage { get; set; }

        public virtual Room? Room { get; set; }
        public virtual InventoryStockItem? InventoryStockItem { get; set; }

        public virtual ICollection<Plant>? Plants { get; set; }

        [InverseProperty(nameof(LightTransfer.ToLight))]
        public virtual ICollection<LightTransfer>? TransfersIn { get; set; }

        [InverseProperty(nameof(LightTransfer.FromLight))]
        public virtual ICollection<LightTransfer>? TransfersOut { get; set; }
    }
}
