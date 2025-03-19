using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models
{
    public abstract class TrackingBase
    {
        public DateTimeOffset? DateCreated { get; set; }

        [ForeignKey("Creator")]
        public string? CreatedUserID { get; set; }

        public DateTimeOffset? DateLastModified { get; set; }

        [ForeignKey("LastModifier")]
        public string? LastModifiedUserID { get; set; }
    }
}
