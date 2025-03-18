using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    [Table("IconCollections", Schema = "Map")]
    public class IconCollection
    {
        public IconCollection() { }

        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int? ParentID { get; set; }

        public IconCollection? Parent { get; set; }

        public ICollection<IconCollection>? Children { get; set; } = [];
        public ICollection<MapIcon> Icons { get; set; } = [];
    }
}
