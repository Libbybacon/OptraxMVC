using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Map
{
    public abstract class MapShape : MapObject
    {
        [Display(Name = "Border Width")]
        public int Weight { get; set; } = 3;

        public ColorRgba ColorBytes { get; set; } = new ColorRgba("#1d52d7");

        public ColorRgba FillColorBytes { get; set; } = new ColorRgba("#1d52d782");

        [MaxLength(15)]
        [Display(Name = "Dash Spacing")]
        public string DashArray { get; set; } = "5 5";

        [MaxLength(20)]
        public string Pattern { get; set; } = "dash";

        [NotMapped]
        public string Color { get; set; } = "#1d52d7";

        [NotMapped]
        [Display(Name = "Fill Color")]
        public string FillColor { get; set; } = "#1d52d782";

        [NotMapped]
        public string? GeometryWKT { get; set; } = null;
    }
}
