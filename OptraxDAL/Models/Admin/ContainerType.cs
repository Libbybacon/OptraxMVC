using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("ContainerTypes", Schema = "Admin")]
    public class ContainerType : BaseDetails
    {
        public ContainerType() { }

        public decimal Capacity { get; set; }

        [Required]
        [MaxLength(50)]
        [ForeignKey("CapacityUoM")]
        [Display(Name = "Capacity UoM")]
        public string UoMName { get; set; } = string.Empty;

        public virtual UoM CapacityUoM { get; set; } = new();
        public virtual ICollection<PlantEvent>? Transplants { get; set; } = [];
    }
}
