using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models
{
    class ProductBatch
    {
        public ProductBatch()
        {
        }

        public required int ID { get; set; }

        public required int ProductID { get; set; }

        public required int BatchNumber { get; set; }

        public int UnitQuantity { get; set; } = 0;

        public required virtual Product Product { get; set; }

        public virtual ICollection<ProductUnit> Units { get; set; } = [];
    }
}
