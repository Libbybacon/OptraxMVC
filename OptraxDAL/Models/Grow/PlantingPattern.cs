using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantingPatterns", Schema = "Grow")]
    public class PlantingPattern : TrackingBaseDetails
    {
        public decimal? Width { get; set; } = 0;
        public decimal? Length { get; set; } = 0;
        public decimal? Radius { get; set; } = 0;
        public decimal? SpaceLeft { get; set; } = 0;
        public decimal? SpaceRight { get; set; } = 0;
        public decimal? PlantSpacing { get; set; } = 0;
        public string? Direction { get; set; } = "Vertical";

        public virtual ICollection<PlantingSection> Sections { get; set; } = [];
    }
}