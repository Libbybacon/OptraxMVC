using OptraxDAL.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OptraxDAL.Models.Inventory
{
    [Table("Resources", Schema = "Inventory")]
    public class Resource : TrackingBase
    {
        public Resource() { }

        public Resource(Category category)
        {
            CategoryID = category.ID;
            Category = category;
        }

        public int ID { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }

        [MaxLength(255)]
        public string? Tags { get; set; } = string.Empty;

        [MaxLength(50)]
        [Display(Name = "Stock Type")]
        [Required(ErrorMessage = "Please select a stock type")]
        public string StockType { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Brand")]
        public string? Manufacturer { get; set; }

        [MaxLength(50)]
        public string? SKU { get; set; }

        [MaxLength(25)]
        [Display(Name = "Default UoM")]
        public string? DefaultUoM { get; set; }

        [MaxLength(25)]
        [Display(Name = "Stock UoM")]
        public string? StockUoM { get; set; }

        public int? SellerID { get; set; }

        public bool NeedsTransferApproval { get; set; } = false;

        public bool Active { get; set; } = true;

        public virtual Category? Category { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; } = [];

        public enum InventoryType
        {
            Plant,
            Durable,
            Consumable,
        }

        [NotMapped]
        public string? Changes { get; set; }

        public ResourceVM ToResourceVM(Category cat0, Category cat1)
        {
            ResourceVM rsrcVM = new()
            {
                Cat0 = $"{cat0.Name}-{cat0.ID}-{cat0.HexColor}",
                Cat1 = $"{cat1.Name}-{cat1.ID}-{cat1.HexColor}",
                ResourceID = ID,
                ResourceName = Name,
                ResourceDesc = Description,
                SKU = SKU,
                Brand = Manufacturer,
                StockType = StockType,
                UoM = DefaultUoM
            };

            return rsrcVM;
        }

    }
}
