﻿using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("Companies", Schema = "Admin")]
    public class Company : TrackingBaseDetails
    {
        public Company() { }

        public int AdminID { get; set; }
        public int PrimaryAddressID { get; set; }
        public virtual AppUser CompanyAdmin { get; set; } = new();

        public virtual ICollection<AppUser> Users { get; set; } = [];
        public virtual ICollection<Address>? Addresses { get; set; } = [];
    }
}
