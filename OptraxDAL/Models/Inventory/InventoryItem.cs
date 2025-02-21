using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryItem
    {
        public InventoryItem() { }

        public InventoryItem(InventoryCategory category)
        {
            CategoryID = category.ID;
            Category = category;
        }

        public int ID { get; set; }
        public int CategoryID { get; set; }

        [MaxLength(50)]
        public string StockType { get; set; } = "";
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(250)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string? Manufacturer { get; set; }
        [MaxLength(50)]
        public string? SKU { get; set; }
        [MaxLength(25)]
        public string? DefaultUOM { get; set; }

        public int? SellerID { get; set; }
        public int? LightTypeID { get; set; }
        public int? ContainerTypeID { get; set; }

        public bool NeedsTransferApproval { get; set; } = false;
        public bool Active { get; set; } = true;

        public virtual LightType? LightType { get; set; }
        public virtual ContainerType? ContainerType { get; set; }
        public virtual InventoryCategory? Category { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; } = [];

        public enum InventoryType
        {
            Plant,
            Light,
            Durable,
            Consumable,
        }

        public List<string> GetCategoryNames()
        {
            if (Category?.Parent != null)
            {
                List<string> orderedNames = [.. GetCategoryNamesRecursive(Category).AsEnumerable().Reverse()];

                orderedNames.Add(Category.Name);

                return orderedNames;
            }
            return [Category?.Name];
        }

        private static List<string> GetCategoryNamesRecursive(InventoryCategory category)
        {
            List<string> names = [];

            if (category.Parent != null)
            {
                names.AddRange(GetCategoryNamesRecursive(category.Parent));
            }

            return names;
        }
    }
}
