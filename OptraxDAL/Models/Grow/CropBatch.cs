using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Batches", Schema = "Grow")]
    public class CropBatch : TrackingBaseDetails
    {
        public int CropId { get; set; }
        public int? SalesOrderId { get; set; }
        public string PropagationType { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? OriginType { get; set; }

        public virtual Crop Crop { get; set; } = new();

        public virtual ICollection<Planting> Plantings { get; set; } = [];

    }
}
