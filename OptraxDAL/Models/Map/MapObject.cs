//using Azure.Core.GeoJson;
using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("MapObjects", Schema = "Map")]
    public abstract class MapObject : TrackingBaseDetails
    {
        [MaxLength(50)]
        public string? Category { get; set; }

        public abstract object ToGeoJSON();
    }
}
