using OptraxDAL.Models.Admin;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Products
{
    public class Product : TrackingBase
    {
        public Product()
        {
            Units = [];
        }

        public int ID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDescription { get; set; }

        [MaxLength(50)]
        [ForeignKey("UnitUoM")]
        public string? UnitUoMName { get; set; }

        public bool Active { get; set; } = true;

        public virtual UoM UnitUoM { get; set; } = new();
        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
