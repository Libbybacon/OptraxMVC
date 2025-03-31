using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class PlotLocation : AreaLocation
    {
        public PlotLocation()
        {
            Level = 4;
            Width = 0;
            Length = 0;
            LocationType = "Plot";
        }
    }
}
