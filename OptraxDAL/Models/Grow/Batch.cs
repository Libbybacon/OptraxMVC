using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Grow
{
    public class Batch : TrackingBase
    {
        public int ID { get; set; }

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

    }
}
