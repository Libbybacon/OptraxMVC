using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models
{
    public class Enums
    {
        public enum PlantType
        {
            Indica,
            Sativa,
            Hybrid
        }

        public enum Cannabinoid
        {
            THC,
            CBD,
            CBN,
        }

        public enum GrowStage
        {
            Seedling,
            Vegetative,
            Flowering,
            Harvest,
            Processing,
            Cure,
            Packaging,
            Sold
        }

        public enum EndProductType
        {
            Flower,
            Trim,
            Extract,
            Concentrate,
            Edible,
            Topical,
            Other
        }

        public enum PlantEvent
        {
            StartSeed1,
            StartClone,
            Transplant,
            Top,
            FIM,
            LST1,
            LST2,
            LST3,
            Defoliate,
            Water,
            Feed,
            Flush,
            Spray,
            Neem,
            DiatomaceousEarth,
            ChangeLight,
            ChangeRoom,
            Harvest
        }

        public enum PlantEventCategory
        {
            Move,
            Prune,
            FeedOrWater,
            PestControl,
            Harvest
        }

        public enum InventoryCategory
        {
            Plant,
            PlantCare,
            Equipment,

            PPE,
            OfficeSupplies,
            ShippingAndPackaging,
            Other
        }

        public enum InventorySubCategory
        {
            Seed,
            Clone,

            Soil,
            Nutrient,
            PestControl,
            
            Light,
            Container,
            PruningOrMaintainance,
            HVAC,
        }

        public enum InventoryUnit
        {
            Each,
            Milligram,
            Gram,
            Kilogram, 
            Ounce,
            Pound,
            Cup,
            Pint,
            Quart,
            Gallon,
            Milliliter,
            Liter,
            Other
        }

        public enum InventoryType
        {
            Consumable,
            Durable,
            Perishable,
            Other
        }

    }
}
