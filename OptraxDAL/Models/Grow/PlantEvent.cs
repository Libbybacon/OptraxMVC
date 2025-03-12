using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantEvents")]
    public class PlantEvent
    {
        public PlantEvent() { }
        public int ID { get; set; }
        public int PlantID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; }

        [MaxLength(25)]
        public string EventType { get; set; } = string.Empty;
        
        [MaxLength(25)]
        public string? EventSubType { get; set; }

        [ForeignKey("User")]
        [MaxLength(450)]
        public string UserID { get; set; } = string.Empty;
        
        [MaxLength(250)]
        public string? Notes { get; set; }
        public string NewPhase { get; set; } = string.Empty;

        [ForeignKey("NewLight")]
        public int NewLightID { get; set; }

        public string PruneType { get; set; } = string.Empty;
        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUoM { get; set; }


        [ForeignKey("Transfer")]
        public int TransferID { get; set; }

        [ForeignKey("NewContainer")]
        public int NewContainerID { get; set; }
       
        [MaxLength(25)]
        public string TreatmentType { get; set; } = string.Empty;
        public int? ProductID { get; set; }
        public decimal? QuantityApplied { get; set; }

        [MaxLength(20)]
        public string? QuantityUoM { get; set; }

        public virtual Plant? Plant { get; set; }
        public virtual AppUser? User { get; set; }
        public virtual Light NewLight { get; set; } = new();
        public virtual ConsumableItem? Product { get; set; }
        public virtual ContainerType? NewContainer { get; set; }
        public virtual InventoryTransfer Transfer { get; set; } = new();
    }

    public enum TreatmentType
    {
        Water,
        Feed,
        Flush,
        PestControl,
        MoldControl
    }

    public enum PruneType
    {
        Top,
        Defoliate,
        FIM,
        LST1,
        LST2,
        LST3,
    }
}
