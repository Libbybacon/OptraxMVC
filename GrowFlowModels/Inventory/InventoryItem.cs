using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Inventory
{
    public class InventoryItem
    {
        public InventoryItem() { }

        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public string? Manufacturer { get; set; }

        public int CategoryID { get; set; }

        public int? SubCategoryID { get; set; }

        public string? SKU { get; set; }

        public string? DefaultUOM { get; set; }

        public bool Active { get; set; } = true;

    }
}
