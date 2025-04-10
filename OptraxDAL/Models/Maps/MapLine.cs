using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
{
    [Table("Lines", Schema = "Map")]
    public class MapLine : MapShape
    {
        public MapLine()
        {
            Color = ColorBytes.ToString();
            Name = "New Line";
        }

        public LineString? LineGeometry { get; set; }

        public override object ToGeoJSON()
        {
            return new
            {
                type = "Feature",
                properties = new
                {
                    id = Id,
                    name = Name,
                    color = ColorBytes.ToString(),
                    weight = Weight,
                    pattern = Pattern,
                    dashArray = DashArray,
                    objType = "Line",
                },
                geometry = new
                {
                    type = "LineString",
                    coordinates = LineGeometry!.Coordinates.Select(c => new[] { c.X, c.Y })
                }
            };
        }
    }
}
