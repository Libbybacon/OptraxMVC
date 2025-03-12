namespace OptraxDAL.Models.Products
{
    public class ProductBatch
    {
        public ProductBatch() { }

        public int ID { get; set; }

        public int ProductID { get; set; }

        public int BatchNumber { get; set; }

        public int UnitQuantity { get; set; } = 0;

        public virtual Product Product { get; set; } = new();

        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
