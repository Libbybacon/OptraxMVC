using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Polygons", Schema = "Map")]
    public class MapPolygon : MapObject
    {
        public MapPolygon() { }
        public int? LocationID { get; set; }

        public int BorderWidth { get; set; } = 1;

        [MaxLength(9)]
        public string BorderColor { get; set; } = "#1d52d7";

        [MaxLength(9)]
        public string FillColor { get; set; } = "#1d52d782";

        [MaxLength(15)]
        public string Pattern { get; set; } = "solid";

        public Polygon PolyGeometry { get; set; } = default!;
        public virtual Admin.Location? Location { get; set; }

        [NotMapped]
        public string? PolyGeometryWKT { get; set; }
    }
}
