using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.BaseClasses
{
    public abstract class TrackingBase : BaseClass
    {
        public DateTimeOffset? DateCreated { get; set; }

        [ForeignKey("Creator")]
        public string? CreatedUserID { get; set; }

        public DateTimeOffset? DateLastModified { get; set; }

        [ForeignKey("LastModifier")]
        public string? LastModifiedUserID { get; set; }
    }
}
