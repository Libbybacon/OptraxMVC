using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Inputs", Schema = "Admin")]
    public class Input : BaseClass
    {
        public Input() { }

        public string InputName { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;
    }
}
