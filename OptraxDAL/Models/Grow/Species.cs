using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Species", Schema = "Grow")]
    public class Species : TrackingBaseDetails
    {
        public Species() { }

        [Column(Order = 0)]
        public string Family { get; set; } = string.Empty;
        [Column(Order = 1)]
        public string Genus { get; set; } = string.Empty;
        [Column(Order = 2)]
        public string SpeciesName { get; set; } = string.Empty;
        [Column(Order = 3)]
        public string? CommonName { get; set; }
        [Column(Order = 4)]
        public string? CustomName { get; set; } // Filled in by user
        [Column(Order = 5)]
        public string? Abbreviation { get; set; } // Filled in by user
        [Column(Order = 6)]
        public string? Description { get; set; }
        [Column(Order = 7)]
        public string PlantType { get; set; } = string.Empty;
        [Column(Order = 8)]
        public string? PlantingDepth { get; set; } //inches
        [Column(Order = 9)]
        public string? PlantSpacing { get; set; }   //inches
        [Column(Order = 10)]
        public string? RowSpacing { get; set; } //inches
        [Column(Order = 11)]
        public bool Blooms { get; set; } = false;
        [Column(Order = 12)]
        public bool Fruits { get; set; } = false;
        [Column(Order = 13)]
        public bool Seeds { get; set; } = false;

        [Column(Order = 14)]
        public string? Height { get; set; }  //inches
        [Column(Order = 15)]
        public string? Spread { get; set; }  //inches



        // Growing Attributes
        [Column(Order = 16)]
        public string? Site { get; set; } // Full sun, shade, etc...
        [Column(Order = 17)]
        public string? Seasons { get; set; } // Spring, Summer, Fall, Winter
        [Column(Order = 18)]
        public string? SoilType { get; set; } // Clay, Loam, Sand, etc...
        [Column(Order = 19)]
        public string? HeatZone { get; set; }
        [Column(Order = 20)]
        public string? HardinessZone { get; set; }
        [Column(Order = 21)]
        public string? PlantingMethods { get; set; } // Direct Seed, Transplant
        [Column(Order = 22)]
        public string? Cycle { get; set; } // Annual, Perennial, Biennial
        [Column(Order = 23)]
        public string? DaysToMaturity { get; set; }
        [Column(Order = 24)]
        public string? HarvestPeriod { get; set; } // Late, Mid, Early, etc
        [Column(Order = 25)]
        public string? PropagationTypes { get; set; } // Seed, Cutting, Division, etc
        [Column(Order = 26)]
        public decimal? WaterNeedsQty { get; set; }
        [Column(Order = 27)]
        [ForeignKey("WaterUOM")]
        public string? WaterQtyUOM { get; set; }
        [Column(Order = 28)]
        public string? WaterNeedsFrequency { get; set; } // Daily, Weekly, etc
        [Column(Order = 29)]
        public string? SoilDrainage { get; set; } // Well, Good, Poor, etc
        [Column(Order = 30)]
        public string? IdealAirTemp { get; set; } // x,y (x = min, y = max)
        [Column(Order = 31)]
        public string? IdealSoilTemp { get; set; }  // x,y (x = min, y = max)
        [Column(Order = 32)]
        public string? IdealHumidity { get; set; }  // x,y (x = min, y = max)
        [Column(Order = 33)]
        public string? IdealLightHours { get; set; }  // x,y (x = min, y = max)
        [Column(Order = 34)]
        public string? IdealpH { get; set; } // x,y (x = min, y = max)


        [Column(Order = 35)]
        public string? PropagationMethods { get; set; } // Seed, Cutting, Bulb, etc...
        [Column(Order = 36)]
        public string? GerminationDays { get; set; }
        [Column(Order = 37)]
        public string? GerminationDetails { get; set; }
        [Column(Order = 38)]
        public bool? HardenOff { get; set; } = false;
        [Column(Order = 39)]
        public string? HardenOffDetails { get; set; }
        [Column(Order = 40)]
        public string? HarvestSignifiers { get; set; } // Blooms 1/2 open...
        [Column(Order = 41)]
        public string? HarvestDetails { get; set; }


        // Crop Attributes
        [Column(Order = 42)]
        public string? CropRotationDetails { get; set; }
        [Column(Order = 43)]
        public string? CommonPests { get; set; }
        [Column(Order = 44)]
        public string? CommonDiseases { get; set; }
        [Column(Order = 45)]
        public string? CompanionPlants { get; set; }
        [Column(Order = 46)]
        public string? AvoidPlants { get; set; }
        [Column(Order = 47)]
        public string? Attracts { get; set; }
        [Column(Order = 48)]
        public string? Repels { get; set; }


        public virtual UoM? WaterUOM { get; set; }
        public virtual ICollection<Crop> Crops { get; set; } = [];
    }
}
