using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptraxDAL.ViewModels
{
    public class PlantVM
    {
        public int PlantID { get; set; }
        public string TrackingID { get; set; } = "";
        public int StrainID { get; set; }
        public int? CropID { get; set; }
        public bool IsMother { get; set; } = false;
        public string StartType { get; set; } = "";
        public string StartPhase { get; set; } = "";
        public string? CurrentPhase { get; set; }
        public string? LocationName { get; set; }
        public string? LocationType { get; set; }
        public int? Quantity { get; set; } = 1;
    }
}
