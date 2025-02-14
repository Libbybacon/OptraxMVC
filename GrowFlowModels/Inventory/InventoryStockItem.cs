using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Inventory
{
    public class InventoryStockItem
    {
        public InventoryStockItem() { }

        public  required int ID { get; set; }
        public required int ItemID { get; set; }
        public string? LotNumber { get; set; }

        public decimal UnitCount { get; set; } = 0;
        public string? UOM { get; set; }
        public string? Status { get; set; }

        public decimal UnitPrice { get; set; } = 0;

        public DateTimeOffset? PurchaseDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
    }
}
