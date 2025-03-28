using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class PlotLocation : Location
    {
        public PlotLocation() { Level = 4; }
    }
}
