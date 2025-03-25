using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Products
{
    [Table("Products", Schema = "Products")]
    public class Product : TrackingBaseDetails
    {
        public Product()
        {
            Units = [];
        }

        [MaxLength(50)]
        [ForeignKey("UnitUoM")]
        public string? UnitUoMName { get; set; }

        public virtual UoM UnitUoM { get; set; } = new();
        public virtual ICollection<ProductItem> Units { get; set; } = [];
    }
}
