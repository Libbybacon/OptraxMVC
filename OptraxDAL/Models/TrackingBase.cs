using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models
{
    public abstract class TrackingBase
    {
        public DateTimeOffset DateCreated { get; set; }

        [ForeignKey("Creator")]
        public string CreatedByID { get; set; } = default!;

        public DateTimeOffset? DateLastModified { get; set; }

        [ForeignKey("LastModifier")]
        public string? LastModifiedByID { get; set; } = default!;
    }
}
