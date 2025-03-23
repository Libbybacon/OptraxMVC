using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Lines", Schema = "Map")]
    public class MapLine : MapObject
    {
        public MapLine()
        {
            Name = "New Line";
        }

        [Display(Name = "Width")]
        public int Weight { get; set; } = 3;

        [MaxLength(9)]
        public string Color { get; set; } = "#1d52d7";

        [MaxLength(15)]
        [Display(Name = "Dash Spacing")]
        public string DashArray { get; set; } = "5 5";


        [MaxLength(20)]
        public string Pattern { get; set; } = "dash";


        public LineString? LineGeometry { get; set; }

        [NotMapped]
        public string LineGeometryWKT { get; set; } = string.Empty;
    }
}
