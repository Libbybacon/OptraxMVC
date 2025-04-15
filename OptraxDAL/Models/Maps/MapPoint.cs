using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
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

        public int IconId { get; set; } = 1;
        public int IconCollectionId { get; set; } = 1;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; } = 0;
        public int? AddressId { get; set; }

        public virtual Icon? Icon { get; set; }
        public virtual Address? Address { get; set; }


        [NotMapped]
        public string IconPath { get; set; } = string.Empty;

        public override object ToGeoJSON()
        {
            return new
            {
                type = "Feature",
                properties = new
                {
                    id = Id,
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
