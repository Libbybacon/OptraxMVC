using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    public interface ILocation
    {

    }

    [Table("InventoryLocations")]
    public abstract class InventoryLocation : ILocation
    {
        public InventoryLocation() { }

        public int ID { get; set; }

        [Display(Name = "Parent Location")]
        public int? ParentID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }

        public bool Active { get; set; } = true;

        public virtual InventoryLocation? Parent { get; set; } = null;

        public virtual ICollection<InventoryLocation> Children { get; set; } = [];
        public virtual ICollection<StockItem> StockItems { get; set; } = [];


        [InverseProperty(nameof(InventoryTransfer.Origin))]
        public virtual ICollection<InventoryTransfer> TransfersOut { get; set; } = [];

        [InverseProperty(nameof(InventoryTransfer.Destination))]
        public virtual ICollection<InventoryTransfer> TransfersIn { get; set; } = [];

        [NotMapped]
        public string LocationType { get; set; } = string.Empty;

        public string GetParentNamesString()
        {
            if (Parent != null)
            {
                List<string> names = [Name, Parent.Name];

                if (Parent.Parent != null)
                {
                    names.AddRange(GetNamesRecursive(Parent.Parent));
                }
                List<string> orderedNames = [.. names.AsEnumerable().Reverse()];

                return string.Join(" > ", orderedNames);
            }
            return Name;
        }

        private static List<string> GetNamesRecursive(InventoryLocation category)
        {
            List<string> names = [category.Name];

            if (category.Parent != null)
            {
                names.AddRange(GetNamesRecursive(category.Parent));
            }
            return names;
        }
    }

    //TODO: Move location types to own class files, add functions
    [Table("InventoryLocations")]
    public class ContainerLocation : InventoryLocation
    {
        public ContainerLocation() { }

        public int ContainerTypeID { get; set; }

        [Required]
        public new string Description { get; set; } = string.Empty;

        public ContainerType? ContainerType { get; set; }
    }

    [Table("InventoryLocations")]
    public class RoomLocation : InventoryLocation
    {
        public RoomLocation() { }

        public virtual ICollection<Crop>? Crops { get; set; } = [];
    }

    [Table("InventoryLocations")]
    public class BuildingLocation : InventoryLocation
    {
        public BuildingLocation() { }

        public int AddressID { get; set; }
        public virtual required Address Address { get; set; } = new();
    }

    [Table("InventoryLocations")]
    public class OffsiteLocation : InventoryLocation
    {
        public OffsiteLocation() { }

        [Required]
        public new string Description { get; set; } = string.Empty;
    }

    public enum LocationType
    {
        Building = 1,
        Room = 2,
        Container = 3,
        Outdoor = 4,
        OffSite = 5,
    }
}
