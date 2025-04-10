using OptraxDAL.Models.Admin;

namespace OptraxDAL.Models.BaseClasses
{
    public abstract class TrackingBase : BaseClass
    {
        public string? UserId { get; set; } = string.Empty;

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateLastModified { get; set; }

        public virtual AppUser? User { get; set; }
    }
}
