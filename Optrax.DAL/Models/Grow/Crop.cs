using OptraxDAL.Models.Products;

namespace OptraxDAL.Models.Grow
{
    public class Crop
    {
        public Crop() { }

        public int ID { get; set; }
        public int StrainID { get; set; }
        public int? BatchID { get; set; }
        public string? Name { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? ExpectedVegDays { get; set; }
        public int? ActualVegDays { get; set; }

        public int? ExpectedFlowerDays { get; set; }
        public int? ActualFlowerDays { get; set; }

        public string? ProductType { get; set; }
        public decimal? ProductQuantity { get; set; }
        public string? ProductQuantityUOM { get; set; }

        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUOM { get; set; }

        public string? Notes { get; set; }

        public required virtual Strain Strain { get; set; }
        public virtual ICollection<Plant> Plants { get; set; } = [];
        public virtual ICollection<ProductItem> ProductItems { get; set; } = [];
    }
}
