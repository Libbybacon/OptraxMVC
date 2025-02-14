using GrowFlow.Models.Crops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models
{
    public class Crop
    {
        public Crop()
        {
            Plants = [];
            Actions = [];
        }

        public int ID { get; set; }

        public int StrainID { get; set; }

        public string? Name { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? ExpectedVegDays { get; set; }
        public int? ActualVegDays { get; set; }

        public int? ExpectedFlowerDays { get; set; }
        public int? ActualFlowerDays { get; set; }

        public int? EndProductTypeID { get; set; }

        public decimal? EndProductQuantity { get; set; }
        public string? EndProductQuantityUOM { get; set; }

        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUOM { get; set; }

        public string? Notes { get; set; }

        public required virtual Strain Strain { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<CropAction> Actions { get; set; }
    }
}
