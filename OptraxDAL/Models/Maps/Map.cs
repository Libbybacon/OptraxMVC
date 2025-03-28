using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Maps
{
    [Table("Maps", Schema = "Map")]
    public class Map : TrackingBaseDetails
    {
        public Map() { }

        public Map(string name)
        {
            Name = name;
        }

        public int? CollectionID { get; set; }

        public virtual ICollection<MapObject>? MapObjects { get; set; } = [];
    }
}
