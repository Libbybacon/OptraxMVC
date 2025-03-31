using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Icons", Schema = "Admin")]
    public class Icon : BaseDetails
    {
        public string ImagePath { get; set; } = default!;

        public virtual ICollection<MapPoint> Points { get; set; } = [];
        public virtual ICollection<IconCollection> Collections { get; set; } = [];
    }
}
