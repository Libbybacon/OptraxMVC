//using Azure.Core.GeoJson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("MapObjects", Schema = "Map")]
    public abstract class MapObject : TrackingBase
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Notes { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        public bool Active { get; set; } = true;
    }
}
