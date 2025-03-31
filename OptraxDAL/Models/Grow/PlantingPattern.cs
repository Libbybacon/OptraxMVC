using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    public abstract class Dimensions
    {
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
    }

    [Table("PlantingPatterns", Schema = "Grow")]
    public class PlantingPattern : TrackingBaseDetails
    {
        public PlantingPattern() { }

        public int LocationID { get; set; }
        public string LocationType { get; set; } = "Field";

        //public int? NumberRows { get; set; }
        //public decimal? RowSpacing { get; set; }

        //public int? NumberBeds { get; set; }
        //public decimal? BedSpacing { get; set; }

        //public int? NumberPlots { get; set; }
        //public decimal? PlotSpacing { get; set; }
    }

    public class RowPattern : Dimensions
    {

    }

}
