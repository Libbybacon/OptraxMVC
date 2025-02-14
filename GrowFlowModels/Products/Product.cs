using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models
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

        public virtual ICollection<ProductUnit> Units { get; set; } = [];
    }
}
