using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Lines", Schema = "Map")]
    public class MapLine : MapObject
    {
        public MapLine() { }

        public int Width { get; set; } = 1;

        [MaxLength(9)]
        public string Color { get; set; } = "#000000";

        [MaxLength(20)]
        public string Pattern { get; set; } = "solid";

        public LineString LineGeometry { get; set; } = default!;

        public virtual ICollection<MapObjectPoint> LinePoints { get; set; } = [];
    }
}
