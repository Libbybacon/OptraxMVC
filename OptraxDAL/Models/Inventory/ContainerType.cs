using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    public class ContainerType
    {
        public ContainerType() { }

        public int ContainerTypeID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }

        public decimal Capacity { get; set; }

        [Required]
        [MaxLength(50)]
        [ForeignKey("CapacityUoM")]
        [Display(Name = "Capacity UoM")]
        public string UoMName { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public virtual UoM CapacityUoM { get; set; } = new();
        public virtual ICollection<PlantEvent>? Transplants { get; set; } = [];
    }
}
