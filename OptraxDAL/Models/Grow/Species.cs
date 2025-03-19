using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Species", Schema = "Grow")]
    public class Species : TrackingBase
    {
        public Species() { }

        public int ID { get; set; }
        public string Family { get; set; } = string.Empty;
        public string Genus { get; set; } = string.Empty;
        public string SpeciesName { get; set; } = string.Empty;
        public string? CommonName { get; set; }
        public string? CustomName { get; set; }
        public string? Abbreviation { get; set; }
        public string? Description { get; set; }

        // Flower Attributes
        public bool Pinch { get; set; } = false;
        public bool Branching { get; set; } = false;
        public string? BloomSizeDescription { get; set; } // Large, Medimum, Small, etc
        public string? BloomShape { get; set; } // Pompon, Anemone, etc
        public string? StemLength { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - centimeters
        public string? FloralCategory { get; set; } // Filler, Focal, Accent, Line, etc
        public string? PlantHeight { get; set; }// x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - centimeters
        public string? Spread { get; set; }// x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) 
        public string? LeafCategory { get; set; } // Linear, Lobed, Reniform, etc...

        // Growing Attributes
        public string? Site { get; set; } // Full sun, shade, etc...
        public string? SoilType { get; set; } // Clay, Loam, Sand, etc...
        public bool? IsInvasive { get; set; }
        public string? HardinessZone { get; set; }
        public string? HeatZone { get; set; }
        public string? Seasons { get; set; } // Spring, Summer, Fall, Winter
        public string? BestPlantingMethod { get; set; } // Direct Seed, Transplant
        public string? PlantType { get; set; } // Annual, Perennial, Biennial
        public string? DaysToMaturity { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable))
        public string? BloomPeriod { get; set; } //Late, Mid, Early, etc
        public string? HarvestPeriod { get; set; } //Late, Mid, Early, etc
        public string? PropagationTypes { get; set; } // Seed, Cutting, Division, etc
        public decimal? WaterNeedsQty { get; set; } // - liters
        public string? WaterNeedsFrequency { get; set; } // Daily, Weekly, etc
        public string? DrainageNeeds { get; set; } // Well, Good, Poor, etc
        public string? IdealDayTemp { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - celcius
        public string? IdealNightTemp { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - celcius
        public string? IdealSoilTemp { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - celcius
        public string? IdealHumidity { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) 
        public string? IdealLightHours { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable))
        public string? IdealpH { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable))


        // Propagation and Planting Attributes
        public string? MainPropagationMethod { get; set; } // Seed, Cutting, Bulb, etc...
        public string? SeedDescription { get; set; } // Small, Round, Spiny, etc...
        public string? SeedStorageDetails { get; set; }
        public string? SeedLifespan { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - weeks
        public bool? ColdStratify { get; set; } = false;
        public string? ColdStratifyDetails { get; set; }
        public string? GerminationTime { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - days
        public string? GerminationDetails { get; set; }
        public bool? HardenOff { get; set; } = false;
        public string? HardenOffDetails { get; set; }
        public string? SeedOrBulbDepth { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable))  - centimeters
        public string? PlantSpacing { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable))  - centimeters
        public string? RowSpacing { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - centimeters


        // Harvest and Storage Attributes
        public string? HarvestSignifiers { get; set; } // Blooms 1/2 open...
        public string? HarvestDetails { get; set; }
        public int? MaxStorageDays { get; set; }
        public string? StorageTemperature { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - celcius
        public string? VaseLife { get; set; } // x, y, z - (1st value is min, 2nd is max, 3rd is average (if applicable)) - days

        // Crop Attributes
        public string? CropRotationDetails { get; set; }
        public string? CommonPests { get; set; }
        public string? CommonDiseases { get; set; }
        public string? CompanionPlants { get; set; }
        public string? AvoidPlants { get; set; }
        public string? Attracts { get; set; }
        public string? Repels { get; set; }
        public string? Resistances { get; set; }
        public string? Uses { get; set; }
        public string? RiskFactors { get; set; }

        public string? Notes { get; set; }
    }
}
