using OptraxDAL.Models.Maps;

namespace OptraxMVC.Areas.Grow.Models
{
    public class MapObjectVM
    {
        public MapObjectVM() { }

        public MapObjectVM(MapObject obj)
        {
            if (obj is MapPoint point)
            {
                MapPoint = point;
                ObjType = "Point";
            }
            else if (obj is MapCircle circle)
            {
                MapCircle = circle;
                ObjType = "Circle";
            }
            else if (obj is MapLine line)
            {
                MapShape = line;
                ObjType = "Line";
            }
            else if (obj is MapPolygon polygon)
            {
                MapShape = polygon;
                ObjType = "Polygon";
            }
        }

        public string ObjType { get; set; } = null!;
        public MapPoint? MapPoint { get; set; } = new MapPoint();
        public MapCircle? MapCircle { get; set; } = new MapCircle();
        public MapShape? MapShape { get; set; } = new MapLine();

        public MapObject GetObject()
        {
            return ObjType switch
            {
                "Point" => MapPoint!,
                "Circle" => MapCircle!,
                "Line" => MapShape!,
                "Polygon" => MapShape!,
                _ => new MapPoint(),
            };
        }
    }
}
