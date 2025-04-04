using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Products
{
    [Table("ProductItems", Schema = "Products")]
    public class ProductItem : BaseClass
    {
        public ProductItem() { }
        public int ProductId { get; set; }
        public int? BatchId { get; set; }
        public string? Status { get; set; }
        public string? Barcode { get; set; }
        public int? LocationId { get; set; }

        public virtual Product Product { get; set; } = new();
        public virtual ProductBatch? Batch { get; set; }
        public virtual Location? CurrentLocation { get; set; }
    }
}
