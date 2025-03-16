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
        public string? CropID { get; set; }
        public int StrainID { get; set; }
        public string TrackingID { get; set; } = string.Empty;
        public string? Strain { get; set; } = string.Empty;
        public bool IsMother { get; set; } = false;
        public string? MotherName { get; set; }
        public string OriginType { get; set; } = string.Empty;
        public string Phase { get; set; } = string.Empty;
        public string? CurrentPhase { get; set; }
        public string? LocationName { get; set; }
        public string? LocationType { get; set; }
        public int? Quantity { get; set; } = 1;
    }
}
