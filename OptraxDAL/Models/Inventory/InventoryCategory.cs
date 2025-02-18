using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryCategory
    {
        public InventoryCategory() { }

        public int ID { get; set; }
        public int? ParentID { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(150)]
        public string? Description { get; set; }
        public bool Active { get; set; } = true;

        public virtual List<InventoryItem> Items { get; set; } = [];
        public virtual InventoryCategory? Parent { get; set; } = null;
        public virtual List<InventoryCategory> Children { get; set; } = [];

        public List<int> GetChildIDs()
        {
            if (Children.Count > 0)
            {
                List<int> childIDs = [.. Children.Select(c => c.ID).ToList()];

                foreach (var child in Children)
                {
                    if (child.Children.Count > 0)
                    {
                        childIDs.AddRange(GetChildIDsRecursive(child));
                    }
                }
                return childIDs;
            }
            return [];
        }

        public static List<int> GetChildIDsRecursive(InventoryCategory category)
        {
            List<int> childIDs = [.. category.Children.Select(c => c.ID).ToList()];

            foreach (var child in category.Children)
            {
                if (child.Children.Count > 0)
                {
                    childIDs.AddRange(GetChildIDsRecursive(child));
                }
            }
            return childIDs;
        }

    }
}
