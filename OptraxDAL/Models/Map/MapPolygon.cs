using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Polygons", Schema = "Map")]
    public class MapPolygon : MapObject
    {
        public MapPolygon() { }

        public int BorderWidth { get; set; } = 1;
        public int? LocationID { get; set; }

        [MaxLength(9)]
        public string BorderColor { get; set; } = "#000000";

        [MaxLength(9)]
        public string FillColor { get; set; } = "#000000";

        [MaxLength(15)]
        public string Pattern { get; set; } = "solid";

        public Polygon PolyGeometry { get; set; } = default!;
        public virtual Admin.Location? Location { get; set; }

        public virtual ICollection<MapObjectPoint> PolyPoints { get; set; } = [];
    }
}
