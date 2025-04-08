namespace OptraxDAL.Models
{
    public class Enums
    {
        public enum PlantType
        {
            Flower,
            Fruit,
            Herb,
            Tree,
            Vegetable
        }

        public enum TaxonType
        {
            Species,
            Variety,
            Cultivar
        }

        public enum PlantPhase
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

        public enum CropEvent
        {
            Plant,
            Harvest
        }

        public enum CropEventCategory
        {
            Sow,
            Till,
            Transplant,
            AmendSoil,
            Harvest
        }

        public enum StockType
        {
            Durable,
            Comsumable
        }

        public enum LocationType
        {
            //Container,
            Room,
            Building,
            //Outdoor,
            //OffSite
        }

        public enum States
        {
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
            Id,
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
