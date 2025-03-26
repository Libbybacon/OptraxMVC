using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("SalesOrders", Schema = "Inventory")]
    public class SalesOrder : TrackingBaseDetails
    {
        public SalesOrder() { }

        public DateTimeOffset Date { get; set; }
        public virtual ICollection<ProductItem> Items { get; set; } = [];
    }
}
