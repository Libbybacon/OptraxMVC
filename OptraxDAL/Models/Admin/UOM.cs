using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    public class UOM
    {
        public UOM() { }

        [Key]
        public string UnitName { get; set; } = string.Empty;

        public string UnitAbbr { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Category { get; set; }

        public decimal? PerQuantity { get; set; }

        [NotMapped]
        public string ListName => PerQuantity.HasValue ? $"{UnitName} ({Math.Round((double)PerQuantity, 2)})" : UnitName;
    }

    public enum UoMCategories
    {
        Area,
        Length,
        Weight,
        Volume,
        Quantity
    }
    public enum InventoryUOM
    {
        Each,
        Case,
        Milligram,
        Gram,
        Kilogram,
        Ounce,
        Pound,
        Cup,
        Pint,
        Quart,
        Gallon,
        Milliliter,
        Liter,
        Other
    }
}
