using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("IconCollections", Schema = "Admin")]
    public class IconCollection
    {
        public IconCollection() { }

        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int? ParentID { get; set; }

        public IconCollection? Parent { get; set; }

        public ICollection<IconCollection>? Children { get; set; } = [];
        public ICollection<Icon> Icons { get; set; } = [];
    }
}
