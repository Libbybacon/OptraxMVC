using OptraxDAL.Models.Inventory;

namespace OptraxDAL.Models.Products
{
    public class ProductItem
    {
        public ProductItem() { }
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int? BatchID { get; set; }
        public string? Status { get; set; }
        public string? Barcode { get; set; }
        public int? InventoryLocationID { get; set; }

        public virtual Product Product { get; set; } = new();
        public virtual ProductBatch? Batch { get; set; }
        public virtual InventoryLocation? CurrentLocation { get; set; }
    }
}
