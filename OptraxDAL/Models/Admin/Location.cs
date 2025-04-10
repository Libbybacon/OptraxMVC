using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Maps;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    public abstract class AddressLocation : Location
    {
        public int? AddressId { get; set; }
        public int? BusinessId { get; set; }

        public Address? Address { get; set; } = new();
        public Business? Business { get; set; }
    }

    public abstract class AreaLocation : Location
    {
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Radius { get; set; }
        public string Shape { get; set; } = "Polygon";

        public virtual ICollection<Planting>? Plantings { get; set; } = [];
    }


    [Table("Locations", Schema = "Admin")]
    public abstract class Location : TrackingBaseDetails
    {
        public Location() { }

        public string LocationType { get; set; } = string.Empty;
        public int? MapObjectId { get; set; }

        [Display(Name = "Parent Location")]
        public int? ParentId { get; set; }
        public int? IconId { get; set; }


        public Icon? Icon { get; set; }
        public MapObject? MapObject { get; set; }
        public Location? Parent { get; set; } = null;


        public virtual ICollection<Location>? Children { get; set; } = [];
        public virtual ICollection<StockItem>? StockItems { get; set; } = [];


        [InverseProperty(nameof(InventoryTransfer.Origin))]
        public virtual ICollection<InventoryTransfer>? TransfersOut { get; set; } = [];

        [InverseProperty(nameof(InventoryTransfer.Destination))]
        public virtual ICollection<InventoryTransfer>? TransfersIn { get; set; } = [];

        [NotMapped]
        public string? ParentString { get; set; }

        [NotMapped]
        public string NameWithType { get => $"{LocationType}: {Name}"; }

        public object ToTreeNode()
        {
            return new
            {
                id = Id.ToString(),
                parent = ParentId?.ToString() ?? "#",
                text = Name,
                type = LocationType.ToLower(),
                state = new
                {
                    opened = true,
                    selected = this is Site site && site.IsPrimary
                }
            };
        }

        public string GetParentNamesString()
        {
            if (Parent != null)
            {
                List<string> names = [NameWithType, Parent.NameWithType];

                if (Parent.Parent != null)
                {
                    names.AddRange(GetNamesRecursive(Parent.Parent));
                }
                List<string> orderedNames = [.. names.AsEnumerable().Reverse()];

                return string.Join(" > ", orderedNames);
            }
            return Name;
        }

        private static List<string> GetNamesRecursive(Location loc)
        {
            List<string> names = [loc.NameWithType];

            if (loc.Parent != null)
            {
                names.AddRange(GetNamesRecursive(loc.Parent));
            }
            return names;
        }
    }


    public enum LocationType
    {
        Site,
        Field,
        Greenhouse,
        Building,
        Room,
        Vehicle,
        Offsite
    }
}
