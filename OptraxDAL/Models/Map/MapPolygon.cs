using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Polygons", Schema = "Map")]
    public class MapPolygon : MapObject
    {
        public MapPolygon()
        {
            Name = "New Polygon";
        }

        public int? LocationID { get; set; }

        [Display(Name = "Border Width")]
        public int Weight { get; set; } = 3;

        [Display(Name = "Border Color")]
        [MaxLength(9)]
        public string Color { get; set; } = "#1d52d7";

        [MaxLength(9)]
        [Display(Name = "Fill Color")]
        public string FillColor { get; set; } = "#1d52d782I'";

        [MaxLength(15)]
        [Display(Name = "Dash Spacing")]
        public string DashArray { get; set; } = "5 5";

        [MaxLength(20)]
        public string Pattern { get; set; } = "dash";

        public Polygon? PolyGeometry { get; set; }
        public virtual Admin.Location? Location { get; set; }

        [NotMapped]
        public string? PolyGeometryWKT { get; set; }
    }
}
