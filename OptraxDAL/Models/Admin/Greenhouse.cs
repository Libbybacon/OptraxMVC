using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Greenhouse : AreaLocation
    {
        public Greenhouse()
        {
            Width = 0;
            Length = 0;
            LocationType = "Greenhouse";
        }
    }
}
