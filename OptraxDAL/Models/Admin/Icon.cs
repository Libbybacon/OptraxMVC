using OptraxDAL.Models.Map;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Icons", Schema = "Admin")]
    public class Icon
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string ImagePath { get; set; } = default!;
        public bool Active { get; set; } = true;

        public virtual ICollection<MapPoint> Points { get; set; } = [];
        public virtual ICollection<IconCollection> Collections { get; set; } = [];
    }
}
