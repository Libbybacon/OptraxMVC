﻿using OptraxDAL.Models.Admin;
using OptraxDAL.ViewModels;
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

        public string GetIconPath()
        {
            return Icon?.ImagePath ?? string.Empty;
        }

        public PointVM ToPointVM()
        {
            return new()
            {
                ID = ID,
                Name = Name,
                Lat = Latitude,
                Long = Longitude,
                Description = Notes,
                IconPath = GetIconPath(),
            };
        }
    }
}
