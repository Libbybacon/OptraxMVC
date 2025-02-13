using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GrowFlow.Models.Grow
{
    [Table("Lights", Schema = "Grow")]
    public class Light
    {
        public Light()
        {
            Active = true;
        }

        public required int ID { get; set; }
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

        public required bool Active { get; set; }

        public virtual Room? Room { get; set; }

        public virtual ICollection<Plant>? Plants { get; set; }
    }
}
