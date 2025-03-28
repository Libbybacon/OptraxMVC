using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Locations", Schema = "Admin")]
    public class OffsiteLocation : AddressLocation
    {
        public OffsiteLocation() { Level = 0; }
    }

}
