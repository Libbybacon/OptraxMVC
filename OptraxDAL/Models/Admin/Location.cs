using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Map;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{

    [Table("Locations", Schema = "Admin")]
    public abstract class Location : TrackingBaseDetails
    {
        public Location() { }

        public int? MapObjectID { get; set; }

        [Display(Name = "Parent Location")]
        public int? ParentID { get; set; }

        [MaxLength(1)]
        public int Level { get; set; }

        public int? IconID { get; set; }

        public virtual Icon? Icon { get; set; }
        public virtual MapObject? MapObject { get; set; }
        public virtual Location? Parent { get; set; } = null;

        public virtual ICollection<Location>? Children { get; set; } = [];
        public virtual ICollection<StockItem>? StockItems { get; set; } = [];


        [InverseProperty(nameof(InventoryTransfer.Origin))]
        public virtual ICollection<InventoryTransfer>? TransfersOut { get; set; } = [];

        [InverseProperty(nameof(InventoryTransfer.Destination))]
        public virtual ICollection<InventoryTransfer>? TransfersIn { get; set; } = [];

        [NotMapped]
        public bool HasAddress { get; set; } = false;

        [NotMapped]
        public string LocationType { get; set; } = string.Empty;

        [NotMapped]
        public string NameWithType { get => $"{LocationType}: {Name}"; }

        public object ToVM()
        {
            return new { ID, Name, Details, ParentID, LocationType, };
        }

        public object ToTreeNode()
        {
            return new { id = ID, parent = ParentID ?? '#', text = Name, type = LocationType.ToLower() };
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

    public abstract class AddressLocation : Location
    {
        public int? AddressID { get; set; }
        public int? BusinessID { get; set; }

        public virtual Address? Address { get; set; } = new();
        public virtual Business? Business { get; set; }
    }

    [Table("Locations", Schema = "Admin")]
    public class VehicleLocation : Location
    {
        public VehicleLocation() { Level = 0; }
    }

    [Table("Locations", Schema = "Admin")]
    public class SiteLocation : AddressLocation
    {
        public SiteLocation()
        {
            Level = 0;
            HasAddress = true;
        }

        public SiteLocation(int addressID, int? businessID)
        {
            Level = 0;
            HasAddress = true;
            AddressID = addressID;
            BusinessID = businessID;
        }

        public SiteLocation(Address? address, Business? business)
        {
            Address = address;
            Business = business;
        }

        public bool IsPrimary { get; set; } = false;


    }


    [Table("Locations", Schema = "Admin")]
    public class GreenhouseLocation : Location
    {
        public GreenhouseLocation() { Level = 1; }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class FieldLocation : Location
    {
        public FieldLocation() { Level = 1; }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class RowLocation : Location
    {
        public RowLocation() { Level = 2; }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("Locations", Schema = "Admin")]
    public class BedLocation : Location
    {
        public BedLocation() { Level = 3; }
    }

    [Table("Locations", Schema = "Admin")]
    public class PlotLocation : Location
    {
        public PlotLocation() { Level = 4; }
    }

    [Table("Locations", Schema = "Admin")]
    public class BuildingLocation : AddressLocation
    {
        public BuildingLocation() { Level = 1; }
        //public BuildingLocation(int addressID, int? businessID)
        //{
        //    Level = 1;
        //    HasAddress = true;
        //    AddressID = addressID;
        //    BusinessID = businessID;
        //}
    }

    [Table("Locations", Schema = "Admin")]
    public class RoomLocation : Location
    {
        public RoomLocation() { Level = 2; }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }



    [Table("Locations", Schema = "Admin")]
    public class OffsiteLocation : AddressLocation
    {
        public OffsiteLocation() { Level = 0; }
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
