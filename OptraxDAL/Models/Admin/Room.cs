using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class Room : Location
    {
        public Room()
        {
            LocationType = "Room";
        }
    }
}
