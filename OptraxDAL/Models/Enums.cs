namespace OptraxDAL.Models
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



        public enum StockType
        {
            Durable,
            Comsumable
        }

        public enum LocationType
        {
            Container,
            Room,
            Building,
            Outdoor,
            OffSite
        }

        public enum States {
            AL,
            AK,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            FL,
            GA,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            OH,
            OK,
            OR,
            PA,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VA,
            WA,
            WV,
            WI,
            WY
        }

    }
}
