using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
{
    [Table("Circles", Schema = "Map")]
    public class MapCircle : MapShape
    {
        public MapCircle()
        {
            Color = ColorBytes.ToString();
            FillColor = FillColorBytes.ToString();
            Name = "New Circle";
        }

        public double Latitude { get; set; } = 0;

        public double Longitude { get; set; } = 0;

        public double Radius { get; set; } = 0;

        public Polygon? Area { get; set; }

        public override object ToGeoJSON()
        {
            return new
            {
                type = "Feature",
                properties = new
                {
                    id = ID,
                    name = Name,
                    color = ColorBytes.ToString(),
                    weight = Weight,
                    fillColor = FillColorBytes.ToString(),
                    dashArray = DashArray,
                    radius = Radius,
                    center = new[] { Longitude, Latitude },
                    objType = "Circle",
                },
                geometry = new
                {
                    type = "Point",
                    coordinates = new[] { Longitude, Latitude }
                }
            };
        }

        public void SetArea()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var center = geometryFactory.CreatePoint(new Coordinate(Longitude, Latitude)); // X = lng, Y = lat

            const double EarthRadius = 6371000.0; // meters
            double radiusDegrees = Radius / EarthRadius * (180.0 / Math.PI);

            Area = center.Buffer(radiusDegrees) as Polygon;
        }
    }
}
