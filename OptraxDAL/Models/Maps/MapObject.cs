using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
{
    [Table("MapObjects", Schema = "Map")]
    public abstract class MapObject : TrackingBaseDetails
    {
        [MaxLength(50)]
        public string? Category { get; set; }

        public int? MapID { get; set; }

        public abstract object ToGeoJSON();

        public virtual Map? Map { get; set; }
    }
}
