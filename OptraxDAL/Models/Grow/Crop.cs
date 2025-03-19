using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Crops", Schema = "Grow")]
    public class Crop : TrackingBase
    {
        public Crop() { }

        public int ID { get; set; }

        [Display(Name = "Crop Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Strain")]
        public int SpeciesID { get; set; }
        public int? VarietyID { get; set; }
        public int? CultivarID { get; set; }
        public string? Notes { get; set; }

        public virtual Species? Species { get; set; }
        public virtual Variety? Variety { get; set; }
        public virtual Cultivar? Cultivar { get; set; }

        public virtual ICollection<Batch> Batches { get; set; } = [];



        //public int GetCurrentVegDays()
        //{
        //    if (VegStart.HasValue && VegEnd == null)
        //    {
        //    }
        //    return 0;
        //}

        //public int GetTotalVegDays()
        //{
        //    if (VegEnd.HasValue && VegStart.HasValue)
        //    {
        //        return (VegEnd.Value - VegStart.Value).Days;
        //    }
        //    return 0;
        //}

        //public int GetCurrentFlowerDays()
        //{
        //    if (FlowerEnd.HasValue && FlowerStart.HasValue)
        //    {
        //        return (DateTime.Now - FlowerStart.Value).Days;
        //    }
        //    return 0;
        //}

        //public int GetTotalFlowerDays()
        //{
        //    if (FlowerEnd.HasValue && FlowerStart.HasValue)
        //    {
        //        return (FlowerEnd.Value - FlowerStart.Value).Days;
        //    }
        //    return 0;
        //}

        //public int GetTotalCycleDays()
        //{
        //    if (EndDate.HasValue && StartDate.HasValue)
        //    {
        //        return (EndDate.Value - StartDate.Value).Days;
        //    }
        //    return 0;
        //}
    }
}
