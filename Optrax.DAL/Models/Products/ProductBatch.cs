namespace OptraxDAL.Models.Products
{
    public class ProductBatch
    {
        public ProductBatch() { }

        public required int ID { get; set; }

        public required int ProductID { get; set; }

        public required int BatchNumber { get; set; }

        public int UnitQuantity { get; set; } = 0;

        public required virtual Product Product { get; set; }

        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
