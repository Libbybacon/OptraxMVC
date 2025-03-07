using OptraxDAL.Models.Grow;
using OptraxDAL.ViewModels;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("Plants")]
    public class Plant : StockItem
    {
        public Plant() { }

        [MaxLength(50)]
        public string TrackingID { get; set; } = "";


        [Required]
        public int StrainID { get; set; } = 0;

        public int? ParentID { get; set; }

        [Required]
        public bool IsMother { get; set; } = false;
        [MaxLength(50)]
        [Display(Name = "Mother Name")]
        public string? MotherName { get; set; }

        [Required]
        public string StartType { get; set; } = "Clone";

        [Required]
        [MaxLength(10)]
        [Display(Name = "Growth Phase")]
        public string StartPhase { get; set; } = "Seed";

        public int? CropID { get; set; }

        public new bool NeedsTransferApproval { get; set; } = true;
        public virtual Strain? Strain { get; set; }
        public virtual Crop? Crop { get; set; } = new();
        public virtual Plant? Parent { get; set; }

        public virtual ICollection<Plant> Children { get; set; } = [];
        public virtual ICollection<PlantEvent> PlantEvents { get; set; } = [];

        [NotMapped]
        public int Quantity { get; set; } = 1;

        [NotMapped]
        [Display(Name = "Create Crop?")]
        public bool CreateCrop { get; set; } = false;


        public Plant NewPlant()
        {
            return new Plant()
            {
                ID = ID,
                InventoryItemID = InventoryItemID,
                PurchaseDate = PurchaseDate,
                ExpirationDate = ExpirationDate,
                LotNumber = LotNumber,
                Status = Status,
                PurchasePrice = PurchasePrice,
                TrackingID = TrackingID,
                StrainID = StrainID,
                ParentID = ParentID,
                IsMother = IsMother,
                MotherName = MotherName,
                StartType = StartType,
                StartPhase = StartPhase,
                CropID = CropID,
                NeedsTransferApproval = true,

                Crop = Crop,
                Strain = Strain,
                InventoryItem = InventoryItem,
                Parent = Parent,
            };
        }
        public PlantVM ToPlantVM()
        {
            return new PlantVM()
            {
                PlantID = ID,
                TrackingID = TrackingID,
                StrainID = StrainID,
                CropID = Crop?.BatchID ?? "",
                IsMother = IsMother,
                StartType = StartType,
                StartPhase = StartPhase,
                CurrentPhase = Crop?.CurrentPhase ?? "",
                LocationName = Crop?.Location?.Name ?? "",
            };
        }
        public enum GrowthPhases
        {
            Seed,
            Seedling,
            Start,
            Veg,
            Flower,
            PreHarvest
        }

        public enum StartTypes
        {
            Seed,
            Start,
            Clone
        }
    }
}
