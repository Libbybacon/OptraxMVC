using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Address", Schema = "Admin")]
    public class Address : TrackingBaseDetails
    {
        public Address() { }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }

        [MaxLength(20)]
        [Display(Name = "Phone")]
        public string? ContactPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Email")]
        public string? ContactEmail { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public int? BusinessID { get; set; }
        public int? BuildingID { get; set; }
        public int? SiteID { get; set; }

        public virtual Business? Business { get; set; }

        public virtual SiteLocation? Site { get; set; }
        public virtual BuildingLocation? Building { get; set; }
    }
}
