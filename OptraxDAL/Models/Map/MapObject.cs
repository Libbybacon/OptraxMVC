//using Azure.Core.GeoJson;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("MapObjects", Schema = "Map")]
    public abstract class MapObject : TrackingBase
    {
        public int ID { get; set; }

        [MaxLength(20)]
        public string ObjectType { get; set; } = string.Empty; // Point, Line, Poly

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Notes { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        public bool Active { get; set; } = true;
    }

    [Table("Points", Schema = "Map")]
    public class MapPoint : MapObject
    {
        public MapPoint()
        {
            ObjectType = "Point";
        }

        public MapPoint(decimal lat, decimal lng)
        {
            ObjectType = "Point";
            Latitude = lat;
            Longitude = lng;
        }

        public int IconID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual MapIcon Icon { get; set; } = null!;
        public virtual Admin.Location? Location { get; set; }

        [NotMapped]
        public string IconPath { get; set; } = string.Empty;
    }

    [Table("Lines", Schema = "Map")]
    public class MapLine : MapObject
    {
        public MapLine()
        {
            ObjectType = "Line";
        }

        public int Width { get; set; } = 1;
        public string Color { get; set; } = "#000000";
        public string Pattern { get; set; } = "solid";
        public LineString LineGeometry { get; set; } = default!;

        public virtual ICollection<MapPoint> Points { get; set; } = [];
    }

    [Table("Polygons", Schema = "Map")]
    public class MapPolygon : MapObject
    {
        public MapPolygon()
        {
            ObjectType = "Polygon";
        }

        public int BorderWidth { get; set; } = 1;
        public string BorderColor { get; set; } = "#000000";
        public string FillColor { get; set; } = "#000000";
        public string Pattern { get; set; } = "solid";
        public Polygon PolyGeometry { get; set; } = default!;

        public virtual Admin.Location? Location { get; set; }
        public virtual ICollection<MapPoint> Points { get; set; } = [];
    }
}
