using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Products
{
    [Table("ProductBatches", Schema = "Products")]
    public class ProductBatch : TrackingBaseDetails
    {
        public ProductBatch() { }

        public int ProductId { get; set; }

        public int BatchNumber { get; set; }

        public int UnitQuantity { get; set; } = 0;

        public virtual Product Product { get; set; } = new();

        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
