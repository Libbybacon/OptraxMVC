using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Admin
{
    [Table("UoMs", Schema = "Admin")]
    public class UoM
    {
        public UoM() { }

        [Key]
        [MaxLength(50)]
        public string UnitName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string UnitAbbr { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
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
    public enum InventoryUoM
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
