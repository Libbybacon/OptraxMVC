using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Admin
{
    public class Enums
    {
        [Key]
        public string ListName { get; set; } = string.Empty;

        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
