using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Points", Schema = "Map")]
    public class MapPoint : MapObject
    {
        public MapPoint()
        {
            Name = "New Point";
        }

        public MapPoint(decimal lat, decimal lng, string name)
        {
            Name = name;
            Latitude = lat;
            Longitude = lng;
        }

        public int IconID { get; set; } = 1;
        public int IconCollectionID { get; set; } = 1;
        public int? LocationID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; } = 0;

        public virtual Icon? Icon { get; set; }
        public virtual Location? Location { get; set; }

        [NotMapped]
        public string IconPath { get; set; } = string.Empty;

        public override object ToGeoJSON()
        {
            return new
            {
                type = "Feature",
                properties = new
                {
                    id = ID,
                    name = Name,
                    objType = "Point",
                    iconPath = GetIconPath()
                },
                geometry = new
                {
                    type = "Point",
                    coordinates = new[] { Longitude, Latitude }
                }
            };
        }
        public string GetIconPath()
        {
            return Icon?.ImagePath ?? string.Empty;
        }
    }
}
