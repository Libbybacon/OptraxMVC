using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Products
{
    [Table("PurchaseOrder", Schema = "Products")]
    public class PurchaseOrder : BaseClass
    {
        public PurchaseOrder() { }

        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? FulfillmentDate { get; set; }
        public DateTimeOffset? ShipDate { get; set; }
        public DateTimeOffset? VerifiedReceivedDate { get; set; }

        public int CustomerID { get; set; }

        public List<StockItem> Items { get; set; } = [];
    }
}
