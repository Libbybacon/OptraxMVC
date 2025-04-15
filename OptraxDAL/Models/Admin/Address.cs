using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Address", Schema = "Admin")]
    public class Address : TrackingBaseDetails
    {
        public Address()
        {
            Name = "";
        }

        [MaxLength(100)]
        public string Address1 { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Address2 { get; set; }

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(10)]
        public string State { get; set; } = string.Empty;

        [MaxLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ContactName { get; set; }

        [MaxLength(20)]
        public string? ContactPhone { get; set; }

        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public int? BusinessId { get; set; }
        public int? BuildingId { get; set; }
        public int? MapPointId { get; set; }
        public int? SiteId { get; set; }

        public virtual Business? Business { get; set; }
        public virtual MapPoint? MapPoint { get; set; }

        public virtual ICollection<AddressLocation>? Locations { get; set; } = [];

        [NotMapped]
        public string AddressString
        {
            get
            {
                return $"{Address1}, {City}, {State} {ZipCode}";
            }
        }
    }
}
