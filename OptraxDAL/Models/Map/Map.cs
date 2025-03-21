using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Map
{
    public class Map
    {
        public Map() { }

        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public int? CollectionID { get; set; }

        public virtual ICollection<MapPoint>? Points { get; set; } = [];
        public virtual ICollection<MapLine>? Lines { get; set; } = [];
        public virtual ICollection<MapPolygon>? Polygons { get; set; } = [];

    }
}
