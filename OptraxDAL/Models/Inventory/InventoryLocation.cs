//using Microsoft.AspNetCore.Mvc;
//using OptraxDAL.Models.Admin;
//using OptraxDAL.Models.Grow;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace OptraxDAL.Models.Inventory
//{

//    [Table("InventoryLocations")]
//    public abstract class InventoryLocation
//    {
//        public InventoryLocation() { }

//        public int ID { get; set; }

//        [Display(Name = "Parent Location")]
//        public int? ParentID { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Name { get; set; } = string.Empty;

//        [MaxLength(250)]
//        public string? Description { get; set; }

//        public bool Active { get; set; } = true;

//        [MaxLength(1)]
//        public int Level { get; set; }

//        public virtual InventoryLocation? Parent { get; set; } = null;

//        public virtual ICollection<InventoryLocation> Children { get; set; } = [];
//        public virtual ICollection<StockItem>? StockItems { get; set; } = [];


//        [InverseProperty(nameof(InventoryTransfer.Origin))]
//        public virtual ICollection<InventoryTransfer> TransfersOut { get; set; } = [];

//        [InverseProperty(nameof(InventoryTransfer.Destination))]
//        public virtual ICollection<InventoryTransfer> TransfersIn { get; set; } = [];

//        [NotMapped]
//        public string LocationType { get; set; } = string.Empty;

//        [NotMapped]
//        public string NameWithType { get => $"{LocationType}: {Name}"; }

//        public string GetParentNamesString()
//        {
//            if (Parent != null)
//            {
//                List<string> names = [NameWithType, Parent.NameWithType];

//                if (Parent.Parent != null)
//                {
//                    names.AddRange(GetNamesRecursive(Parent.Parent));
//                }
//                List<string> orderedNames = [.. names.AsEnumerable().Reverse()];

//                return string.Join(" > ", orderedNames);
//            }
//            return Name;
//        }

//        private static List<string> GetNamesRecursive(InventoryLocation loc)
//        {
//            List<string> names = [loc.NameWithType];

//            if (loc.Parent != null)
//            {
//                names.AddRange(GetNamesRecursive(loc.Parent));
//            }
//            return names;
//        }
//    }

//    [Table("InventoryLocations")]
//    public class VehicleLocation : InventoryLocation
//    {
//        public VehicleLocation()
//        {
//            Level = 0;
//        }
//    }

//    [Table("InventoryLocations")]
//    public class SiteLocation : InventoryLocation
//    {
//        public SiteLocation()
//        {
//            Level = 0;
//        }

//        public bool IsPrimary { get; set; } = false;
//        public int? BusinessID { get; set; }

//        public virtual Business? Business { get; set; }
//    }


//    [Table("InventoryLocations")]
//    public class GreenhouseLocation : InventoryLocation
//    {
//        public GreenhouseLocation()
//        {
//            Level = 1;
//        }

//        public virtual ICollection<Crop>? Crops { get; set; } = [];
//    }

//    [Table("InventoryLocations")]
//    public class FieldLocation : InventoryLocation
//    {
//        public FieldLocation()
//        {
//            Level = 1;
//        }

//        public virtual ICollection<Crop>? Crops { get; set; } = [];
//    }

//    [Table("InventoryLocations")]
//    public class RowLocation : InventoryLocation
//    {
//        public RowLocation()
//        {
//            Level = 2;
//        }

//        public virtual ICollection<Crop>? Crops { get; set; } = [];
//    }

//    [Table("InventoryLocations")]
//    public class BedLocation : InventoryLocation
//    {
//        public BedLocation()
//        {
//            Level = 3;
//        }
//    }

//    [Table("InventoryLocations")]
//    public class PlotLocation : InventoryLocation
//    {
//        public PlotLocation()
//        {
//            Level = 4;
//        }
//    }

//    [Table("InventoryLocations")]
//    public class BuildingLocation : InventoryLocation
//    {
//        public BuildingLocation()
//        {
//            Level = 1;
//        }

//        public int AddressID { get; set; }
//        public int BusinessID { get; set; }


//        [BindProperty]
//        public virtual Address Address { get; set; } = new();
//        public virtual Business? Business { get; set; } = new();

//    }

//    [Table("InventoryLocations")]
//    public class RoomLocation : InventoryLocation
//    {
//        public RoomLocation()
//        {
//            Level = 2;
//        }

//        public virtual ICollection<Crop>? Crops { get; set; } = [];
//    }



//    [Table("InventoryLocations")]
//    public class OffsiteLocation : InventoryLocation
//    {
//        public OffsiteLocation() { }

//        public int? AddressID { get; set; }

//        public virtual Address? Address { get; set; }
//        public virtual Business? Business { get; set; }
//    }

//    public enum LocationType
//    {
//        Site,
//        Field,
//        Row,
//        Bed,
//        Plot,
//        Greenhouse,
//        Building,
//        Room,
//        Vehicle,
//        Offsite
//    }
//}
