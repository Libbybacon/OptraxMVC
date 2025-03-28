﻿using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Plantings", Schema = "Grow")]
    public class Planting : TrackingBaseDetails
    {
        public Planting() { }

        public int CropID { get; set; }

        [MaxLength(50)]
        [ForeignKey("Batch")]
        [Display(Name = "Batch ID")]
        public int? BatchID { get; set; }

        public int LocationID { get; set; }

        [Required]
        [Display(Name = "Current Stage")]
        public string CurrentStage { get; set; } = string.Empty;

        [Display(Name = "Waste Quantity")]
        public decimal? WasteQuantity { get; set; }

        [Display(Name = "Waste Quantity UoM")]
        public string? WasteQuantityUoM { get; set; }

        public virtual Crop Crop { get; set; } = new();
        public virtual Batch? Batch { get; set; }
        public virtual Location Location { get; set; } = default!;

        public virtual ICollection<ProductItem> ProductItems { get; set; } = [];
    }
}
