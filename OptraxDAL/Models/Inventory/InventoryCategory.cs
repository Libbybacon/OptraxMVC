using OptraxDAL.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    public class InventoryCategory
    {
        public InventoryCategory() { }

        public int ID { get; set; }
        public int? ParentID { get; set; }


        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(150)]
        public string? Description { get; set; }
        [MaxLength(10)]
        public string? HexColor { get; set; } = "#FFFFFF";
        [MaxLength(10)]
        public string? TextColor { get; set; } = "#00000000";
        public bool Active { get; set; } = true;

        public virtual List<InventoryItem> Items { get; set; } = [];
        public virtual InventoryCategory? Parent { get; set; } = null;
        public virtual List<InventoryCategory> Children { get; set; } = [];

        [NotMapped]
        public string ListName => ParentID.HasValue ? $"{Parent?.Name} - {Name}" : Name;

        [NotMapped]
        public List<TagVM> ChildTags { get; set; } = [];

        [NotMapped]
        public List<TagVM>? ParentTags { get; set; }

        [NotMapped]
        public string? Changes { get; set; }

        public bool IsTop()
        {
            return ID > 0 && ParentID == null;
        }

        public string NameNoSpace()
        {
            return Name.Replace(" ", "");
        }

        public List<TagVM> GetChildTags()
        {
            if (Children.Count > 0)
            {
                List<TagVM> tags = [.. Children.Select(c => new TagVM { ID = c.ID, Name = c.Name, Color = c.HexColor })];

                return tags;
            }

            return [];
        }

        public List<TagVM> GetParentTags()
        {
            if (Parent != null)
            {
                List<TagVM> tags = [new TagVM { ID = Parent.ID, Name = Parent.Name, Color = Parent.HexColor }];

                if (Parent.Parent != null)
                {
                    tags.AddRange([.. GetParentTagsRecursive(Parent.Parent)]);
                }
                return tags;
            }

            return [];
        }
        private static List<TagVM> GetParentTagsRecursive(InventoryCategory cat)
        {
            List<TagVM> tags = [new TagVM { ID = cat.ID, Name = cat.Name, Color = cat.HexColor }];

            if (cat.Parent != null)
            {
                tags.AddRange([.. GetParentTagsRecursive(cat.Parent)]);
                return tags;
            }

            return tags;
        }

        public List<int> GetChildIDs()
        {
            if (Children.Count > 0)
            {
                List<int> childIDs = [ID, .. Children.Select(c => c.ID).ToList()];

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

        private static List<int> GetChildIDsRecursive(InventoryCategory category)
        {
            List<int> childIDs = [.. category.Children.Select(c => c.ID)];

            foreach (var child in category.Children)
            {
                if (child.Children.Count > 0)
                {
                    childIDs.AddRange(GetChildIDsRecursive(child));
                }
            }
            return childIDs;
        }

        public List<string> GetChildNamesList()
        {
            if (Children != null)
            {
                List<string> names = [.. Children.Select(c => c.Name)];

                foreach (var child in Children)
                {
                    if (child.Children.Count > 0)
                    {
                        names.AddRange(GetChildNamesRecursive(child));
                    }
                }

                return [.. names.AsEnumerable().Reverse()];
            }
            return [Name];
        }

        private static List<string> GetChildNamesRecursive(InventoryCategory cat)
        {
            List<string> names = [cat.Name];

            if (cat.Children.Count > 0)
            {
                foreach (var child in cat.Children)
                {
                    if (child.Children.Count > 0)
                    {
                        names.AddRange(GetChildNamesRecursive(child));
                    }
                }
            }
            return names;
        }

        public List<string> GetParentNamesList()
        {
            if (Parent != null)
            {
                List<string> names = [Name, Parent.Name];

                if (Parent.Parent != null)
                {
                    names.AddRange(GetParentNamesRecursive(Parent.Parent));
                }

                return [.. names.AsEnumerable().Reverse()];
            }
            return [Name];
        }

        private static List<string> GetParentNamesRecursive(InventoryCategory category)
        {
            List<string> names = [category.Name];

            if (category.Parent != null)
            {
                names.AddRange(GetParentNamesRecursive(category.Parent));
            }
            return names;
        }
    }
}
