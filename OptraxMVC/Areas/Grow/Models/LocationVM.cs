using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations;

namespace OptraxMVC.Areas.Grow.Models
{
    public class LocationVM
    {
        public LocationVM() { }

        public LocationVM(Location loc, string? parentID = null)
        {
            ID = loc.ID;
            Name = loc.Name;
            Level = loc.Level;
            Details = loc.Details;
            ParentID = !string.IsNullOrEmpty(parentID) ? (int.TryParse(parentID, out int id) ? id : null) : loc.ParentID;
            LocationType = loc.LocationType;

            IconID = loc.IconID;
            MapObjectID = loc.MapObjectID;

            IsPrimary = loc is SiteLocation site && site.IsPrimary;

            TreeNode = loc.ToTreeNode();

            if (loc is AddressLocation addLoc)
            {
                HasAddress = true;
                AddressID = addLoc.AddressID;
                Address = addLoc.Address;

                BusinessID = addLoc.BusinessID;
                Business = addLoc.Business;
            }

            if (loc is AreaLocation areaLoc)
            {
                HasArea = true;
                Length = areaLoc.Length;
                Width = areaLoc.Width;
                if (loc.Parent is AreaLocation parent)
                {
                    ParentLength = parent.Length;
                    ParentWidth = parent.Width;
                }
            }
        }

        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string? Details { get; set; }
        public int? ParentID { get; set; }
        public string LocationType { get; set; } = string.Empty;

        public int? IconID { get; set; }
        public int? MapObjectID { get; set; }

        public bool HasArea { get; set; } = false;
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? ParentLength { get; set; }
        public decimal? ParentWidth { get; set; }

        public bool HasAddress { get; set; } = false;
        public int? AddressID { get; set; }
        public int? BusinessID { get; set; }

        public bool IsPrimary { get; set; } = false;
        public bool IsFirstSite { get; set; } = false;


        public Map? Map { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Business? Business { get; set; }


        public string? Changes { get; set; }
        public string? ParentString { get; set; }

        public object? TreeNode { get; set; }

        public LocationVM LoadVM(string type, string? parentID = null)
        {
            LocationVM vm = type.ToLower() switch
            {

                "site" => new LocationVM(new SiteLocation()),
                "field" => new LocationVM(new FieldLocation(), parentID),
                "row" => new LocationVM(new RowLocation(), parentID),
                "bed" => new LocationVM(new BedLocation(), parentID),
                "plot" => new LocationVM(new PlotLocation(), parentID),
                "greenhouse" => new LocationVM(new GreenhouseLocation(), parentID),
                "building" => new LocationVM(new BuildingLocation(), parentID),
                "room" => new LocationVM(new RoomLocation(), parentID),
                "offsite" => new LocationVM(new OffsiteLocation()),
                "firstsite" => new LocationVM(new SiteLocation()) { IsFirstSite = true, IsPrimary = true },
                _ => new LocationVM(new SiteLocation()),
            };

            return vm;
        }
    }
}
