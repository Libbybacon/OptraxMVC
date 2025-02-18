namespace OptraxDAL.Models.Products
{
    public class Product
    {
        public Product()
        {
            Units = [];
        }

        public int ID { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public int? ProductUnitUOM { get; set; }
        public bool Active { get; set; } = true;

        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
