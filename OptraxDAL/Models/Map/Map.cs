using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("Maps", Schema = "Map")]
    public class Map : TrackingBaseDetails
    {
        public Map() { }

        public int? CollectionID { get; set; }

        public virtual ICollection<MapPoint>? Points { get; set; } = [];
        public virtual ICollection<MapPoint>? Circles { get; set; } = [];
        public virtual ICollection<MapLine>? Lines { get; set; } = [];
        public virtual ICollection<MapPolygon>? Polygons { get; set; } = [];

    }
}
