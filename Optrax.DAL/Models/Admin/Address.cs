using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Admin
{
    public class Address
    {
        public Address() { }

        [Key]
        public int ID { get; set; }

        public int? BuildingID { get; set; }

        public int? CompannyID { get; set; }

        public required string Address1 { get; set; }
        public string? Address2 { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }

        public required string ZipCode { get; set; }

        public string? ContactName { get; set; }

        public string? ContactPhone { get; set; }

        public string? ContactEmail { get; set; }

        public virtual Building? Building { get; set; }

        public virtual Company? Company { get; set; }

    }
}
