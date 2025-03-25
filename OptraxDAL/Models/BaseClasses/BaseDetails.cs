using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.BaseClasses
{
    public abstract class BaseDetails : BaseClass
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Details { get; set; }
    }
}
