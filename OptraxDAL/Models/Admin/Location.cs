using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Map;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{

    [Table("Locations", Schema = "Admin")]
    public abstract class Location : TrackingBase
    {
        public Location() { }

        public int ID { get; set; }

        public int? MapObjectID { get; set; }

        [Display(Name = "Parent Location")]
        public int? ParentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        [MaxLength(1)]
        public int Level { get; set; }

        public int? IconID { get; set; }

        public virtual Icon? Icon { get; set; }
        public virtual MapObject? MapObject { get; set; }
        public virtual Location? Parent { get; set; } = null;

        public virtual ICollection<Location> Children { get; set; } = [];
        public virtual ICollection<StockItem>? StockItems { get; set; } = [];


        [InverseProperty(nameof(InventoryTransfer.Origin))]
        public virtual ICollection<InventoryTransfer> TransfersOut { get; set; } = [];

        [InverseProperty(nameof(InventoryTransfer.Destination))]
        public virtual ICollection<InventoryTransfer> TransfersIn { get; set; } = [];



        [NotMapped]
        public string LocationType { get; set; } = string.Empty;

        [NotMapped]
        public string NameWithType { get => $"{LocationType}: {Name}"; }

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

    [Table("Locations", Schema = "Admin")]
    public class VehicleLocation : Location
    {
        public VehicleLocation()
        {
            Level = 0;
        }
    }

    [Table("Locations", Schema = "Admin")]
    public class SiteLocation : Location
    {
        public SiteLocation()
        {
            Level = 0;
        }

        public bool IsPrimary { get; set; } = false;
        public int? BusinessID { get; set; }

        public virtual Business? Business { get; set; }
    }


    [Table("Locations", Schema = "Admin")]
    public class GreenhouseLocation : Location
    {
        public GreenhouseLocation() { }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class FieldLocation : Location
    {
        public FieldLocation() { }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class RowLocation : Location
    {
        public RowLocation() { }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class BedLocation : Location
    {
        public BedLocation() { }
    }

    [Table("Locations", Schema = "Admin")]
    public class PlotLocation : Location
    {
        public PlotLocation() { }
    }

    [Table("Locations", Schema = "Admin")]
    public class BuildingLocation : Location
    {
        public BuildingLocation() { }

        public int AddressID { get; set; }
        public int BusinessID { get; set; }


        [BindProperty]
        public virtual Address Address { get; set; } = new();
        public virtual Business? Business { get; set; } = new();

    }

    [Table("Locations", Schema = "Admin")]
    public class RoomLocation : Location
    {
        public RoomLocation() { }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }



    [Table("Locations", Schema = "Admin")]
    public class OffsiteLocation : Location
    {
        public OffsiteLocation()
        {
            Level = 0;
        }

        public int? AddressID { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Business? Business { get; set; }
    }

    public enum LocationType
    {
        Site,
        Field,
        Row,
        Bed,
        Plot,
        Greenhouse,
        Building,
        Room,
        Vehicle,
        Offsite
    }
}
