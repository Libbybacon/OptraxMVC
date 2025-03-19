using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Batches", Schema = "Grow")]
    public class Batch : TrackingBase
    {
        public int ID { get; set; }

        public int CropID { get; set; }
        public int? SalesOrderID { get; set; }

        [Required]
        [MaxLength(100)]
        public string BatchName { get; set; } = string.Empty;
        public string PropagationType { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }

        [MaxLength(50)]
        public string? OriginType { get; set; }
        public bool Active { get; set; } = true;

        public virtual Crop Crop { get; set; } = new();

        public virtual ICollection<Planting> Plantings { get; set; } = [];

    }
}
