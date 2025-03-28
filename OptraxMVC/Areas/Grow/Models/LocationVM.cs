﻿using Microsoft.AspNetCore.Mvc.Rendering;
using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations;

namespace OptraxMVC.Areas.Grow.Models
{
    public class LocationVM
    {
        public LocationVM() { }

        public LocationVM(Location loc)
        {
            ID = loc.ID;
            Name = loc.Name;
            Details = loc.Details;
            IconID = loc.IconID;
            ParentID = loc.ParentID;
            Level = loc.Level;
            LocationType = loc.LocationType;
            HasAddress = loc.HasAddress;
            IsPrimary = loc is SiteLocation site && site.IsPrimary;

            if (loc is AddressLocation addLoc)
            {
                AddressID = addLoc.AddressID;
                Address = addLoc.Address;

                BusinessID = addLoc.BusinessID;
                Business = addLoc.Business;
            }
        }
        public int ID { get; set; }
        public bool? IsPrimary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public string? Details { get; set; }
        public int? IconID { get; set; }
        public int? ParentID { get; set; }
        public int Level { get; set; }
        public string LocationType { get; set; } = string.Empty;

        public bool HasAddress { get; set; } = false;
        public int? AddressID { get; set; }
        public int? BusinessID { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Business? Business { get; set; }

        public List<SelectListItem> AvailableParents { get; set; } = [];
    }
}
