using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Circles", Schema = "Map")]
    public class MapCircle : MapObject
    {
        public MapCircle()
        {
            Name = "New Circle";
        }

        public double Latitude { get; set; } = 0;

        public double Longitude { get; set; } = 0;

        public double Radius { get; set; } = 0;

        [Display(Name = "Border Width")]
        public int Weight { get; set; } = 3;

        [MaxLength(9)]
        public string Color { get; set; } = "#1d52d7";

        [MaxLength(9)]
        [Display(Name = "Border Color")]
        public string FillColor { get; set; } = "#1d52d782I'";

        [MaxLength(15)]
        [Display(Name = "Dash Spacing")]
        public string DashArray { get; set; } = "5 5";

        [MaxLength(20)]
        public string Pattern { get; set; } = "dash";

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Polygon? Area { get; private set; }
    }
}
