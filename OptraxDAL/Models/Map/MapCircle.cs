using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Circles", Schema = "Map")]
    public class MapCircle : MapObject
    {
        public MapCircle() { }

        public double Latitude { get; set; } = 0;

        public double Longitude { get; set; } = 0;

        public double Radius { get; set; } = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public Polygon? Area { get; private set; }

        public int BorderWidth { get; set; } = 1;

        [MaxLength(9)]
        public string BorderColor { get; set; } = "#1d52d7";

        [MaxLength(9)]
        public string FillColor { get; set; } = "#1d52d782I'";

        [MaxLength(15)]
        public string DashArray { get; set; } = "5 5";
    }
}
