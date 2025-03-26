using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("IconCollections", Schema = "Admin")]
    public class IconCollection : BaseDetails
    {
        public IconCollection() { }

        public int? ParentID { get; set; }

        public IconCollection? Parent { get; set; }

        public ICollection<IconCollection>? Children { get; set; } = [];
        public ICollection<Icon> Icons { get; set; } = [];
    }
}
