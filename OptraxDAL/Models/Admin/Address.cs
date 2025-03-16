using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Admin
{

    public class Address
    {
        public Address() { }

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string? Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ContactName { get; set; }

        [MaxLength(20)]
        [RegularExpression(@"\(\d{3}\)\d{3}-\d{4}", ErrorMessage = "Phone number must contain 10 digits.")]

        public string? ContactPhone { get; set; }

        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        public int? BusinessID { get; set; }
        public int? BuildingID { get; set; }

        public virtual Business? Business { get; set; }

        public virtual BuildingLocation? Building { get; set; }
    }
}
