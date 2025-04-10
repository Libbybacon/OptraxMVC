using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Field : AreaLocation
    {
        public Field()
        {
            Width = 3;
            Length = 30;
            LocationType = "Field";
        }
    }
}
