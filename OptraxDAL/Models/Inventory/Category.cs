using OptraxDAL.Models.BaseClasses;
using OptraxDAL.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Categories", Schema = "Inventory")]
    public class Category : BaseDetails
    {
        public Category() { }
        public int? ParentId { get; set; }

        [MaxLength(10)]
        public string? HexColor { get; set; } = "#FFFFFF";
        [MaxLength(10)]
        public string? TextColor { get; set; } = "#00000000";

        public virtual List<Resource> Resources { get; set; } = [];
        public virtual Category? Parent { get; set; } = null;
        public virtual List<Category> Children { get; set; } = [];

        [NotMapped]
        public string ListName => ParentId.HasValue ? $"{Parent?.Name} - {Name}" : Name;

        [NotMapped]
        public List<TagVM> ChildTags { get; set; } = [];

        [NotMapped]
        public List<TagVM>? ParentTags { get; set; }

        public bool IsTop()
        {
            return Id > 0 && ParentId == null;
        }

        public string NameNoSpace()
        {
            return Name.Replace(" ", "");
        }

        public List<TagVM> GetChildTags()
        {
            if (Children.Count > 0)
            {
                List<TagVM> tags = [.. Children.Select(c => new TagVM { Id = c.Id, Name = c.Name, Color = c.HexColor })];

                return tags;
            }

            return [];
        }

        public List<TagVM> GetParentTags()
        {
            if (Parent != null)
            {
                List<TagVM> tags = [new TagVM { Id = Parent.Id, Name = Parent.Name, Color = Parent.HexColor }];

                if (Parent.Parent != null)
                {
                    tags.AddRange([.. GetParentTagsRecursive(Parent.Parent)]);
                }
                return tags;
            }

            return [];
        }
        private static List<TagVM> GetParentTagsRecursive(Category cat)
        {
            List<TagVM> tags = [new TagVM { Id = cat.Id, Name = cat.Name, Color = cat.HexColor }];

            if (cat.Parent != null)
            {
                tags.AddRange([.. GetParentTagsRecursive(cat.Parent)]);
                return tags;
            }

            return tags;
        }

        public List<int> GetChildIds()
        {
            if (Children.Count > 0)
            {
                List<int> childIds = [Id, .. Children.Select(c => c.Id).ToList()];

                foreach (var child in Children)
                {
                    if (child.Children.Count > 0)
                    {
                        childIds.AddRange(GetChildIdsRecursive(child));
                    }
                }
                return childIds;
            }
            return [];
        }

        private static List<int> GetChildIdsRecursive(Category category)
        {
            List<int> childIds = [.. category.Children.Select(c => c.Id)];

            foreach (var child in category.Children)
            {
                if (child.Children.Count > 0)
                {
                    childIds.AddRange(GetChildIdsRecursive(child));
                }
            }
            return childIds;
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

        private static List<string> GetChildNamesRecursive(Category cat)
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

        private static List<string> GetParentNamesRecursive(Category category)
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
