using Microsoft.AspNetCore.Mvc.Rendering;
using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations;

namespace OptraxMVC.Areas.Grow.Models
{
    public class LocationVM(Location loc)
    {

        public string Type { get; set; } = loc.LocationType;

        public int ID { get; set; } = loc.ID;

        public bool IsPrimary = loc is SiteLocation site && site.IsPrimary;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = loc.Name;
        public string? Details { get; set; } = loc.Details;
        public int? IconID { get; set; }
        public int? ParentID { get; set; } = loc.ParentID;
        public int Level { get; set; } = loc.Level;
        public string LocationType { get; set; } = loc.LocationType;

        public bool HasAddress => loc.HasAddress;

        public int? AddressID { get; set; }
        public int? BusinessID { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Business? Business { get; set; }

        public List<SelectListItem> AvailableParents { get; set; } = [];
    }


}
