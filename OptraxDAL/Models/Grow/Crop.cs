using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace OptraxDAL.Models.Grow
{
    public class Crop
    {
        public Crop() { }

        public int ID { get; set; }
        [Display(Name="Crop Name")]
        public string? Name { get; set; }

        [Display(Name = "Strain")]
        public int StrainID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Batch ID")]
        public string? BatchID { get; set; }

        public int? LocationID { get; set; }

        [Required]
        [Display(Name = "Current Phase")]
        public string CurrentPhase { get; set; } = "";

        [Display(Name = "Start Date")]
        public DateTimeOffset? StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? VegStart { get; set; }
        public DateTimeOffset? VegEnd { get; set; }

        public DateTimeOffset? FlowerStart { get; set; }
        public DateTimeOffset? FlowerEnd { get; set; }

        [Display(Name = "Expected Veg Days")]
        public int? ExpectedVegDays { get; set; }
        [Display(Name = "Expected Flower Days")]
        public int? ExpectedFlowerDays { get; set; }

        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUOM { get; set; }

        public string? Notes { get; set; }

        public virtual RoomLocation? Location { get; set; }
        public virtual Strain? Strain { get; set; }
        public virtual ICollection<Plant> Plants { get; set; } = [];
        public virtual ICollection<ProductItem> ProductItems { get; set; } = [];


        public int GetCurrentVegDays()
        {
            if (VegStart.HasValue && VegEnd == null)
            {
            }
            return 0;
        }

        public int GetTotalVegDays()
        {
            if (VegEnd.HasValue && VegStart.HasValue)
            {
                return (VegEnd.Value - VegStart.Value).Days;
            }
            return 0;
        }

        public int GetCurrentFlowerDays()
        {
            if (FlowerEnd.HasValue && FlowerStart.HasValue)
            {
                return (DateTime.Now - FlowerStart.Value).Days;
            }
            return 0;
        }

        public int GetTotalFlowerDays()
        {
            if (FlowerEnd.HasValue && FlowerStart.HasValue)
            {
                return (FlowerEnd.Value - FlowerStart.Value).Days;
            }
            return 0;
        }

        public int GetTotalCycleDays()
        {
            if (EndDate.HasValue && StartDate.HasValue)
            {
                return (EndDate.Value - StartDate.Value).Days;
            }
            return 0;
        }
    }
}
