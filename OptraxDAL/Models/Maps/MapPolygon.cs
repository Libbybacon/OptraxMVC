using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
{
    [Table("Polygons", Schema = "Map")]
    public class MapPolygon : MapShape
    {
        public MapPolygon()
        {
            Color = ColorBytes.ToString();
            FillColor = FillColorBytes.ToString();
            Name = "New Polygon";
        }

        public int? LocationId { get; set; }

        public Polygon? PolyGeometry { get; set; }


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
                    fillColor = FillColorBytes.ToString(),
                    objType = "Polygon",
                },
                geometry = new
                {
                    type = "Polygon",
                    coordinates = new[] { CloseRing(PolyGeometry!.Coordinates) }
                }
            };
        }

        private static double[][] CloseRing(Coordinate[] coords)
        {
            var points = coords.Select(c => new[] { c.X, c.Y }).ToList();

            if (!points.First().SequenceEqual(points.Last()))
            {
                points.Add(points.First());
            }

            return [.. points];
        }
    }
}
