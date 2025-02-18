using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantEvents")]
    public abstract class PlantEvent
    {
        public PlantEvent() { }
        public int ID { get; set; }
        public int PlantID { get; set; }
        public DateTimeOffset Date { get; set; }
        public required string EventType { get; set; }
        public string? EventSubType { get; set; }
        public int UserID { get; set; }
        public string? Notes { get; set; }

        public virtual required Plant Plant { get; set; }
        public virtual required AppUser Employee { get; set; }
    }

    [Table("PlantEvents")]
    public class TreatmentEvent : PlantEvent
    {
        public TreatmentEvent() { }

        public required string TreatmentType { get; set; }
        public int? ProductID { get; set; }
        public decimal? QuantityApplied { get; set; }
        public string? QuantityUOM { get; set; }
        public virtual ConsumableItem? Product { get; set; }
    }

    public enum TreatmentType
    {
        Water,
        Feed,
        Flush,
        PestControl,
        MoldControl
    }

    [Table("PlantEvents")]
    public class TransplantEvent : PlantEvent
    {
        public TransplantEvent() { }
        public int NewContainerID { get; set; }
        public virtual required ContainerType NewContainer { get; set; }
    }

    [Table("PlantEvents")]
    public class LightEvent : PlantEvent
    {
        public LightEvent() { }
        public int NewLightID { get; set; }
        public virtual required Light NewLight { get; set; }
    }


    [Table("PlantEvents")]
    public class TransferEvent : PlantEvent
    {
        public TransferEvent() { }
        public int TransferID { get; set; }
        public virtual required InventoryTransfer Transfer { get; set; }
    }

    [Table("PlantEvents")]
    public class GrowthEvent : PlantEvent
    {
        public GrowthEvent() { }
        public required string NewPhase { get; set; }
    }

    [Table("PlantEvents")]
    public class PruneEvent : PlantEvent
    {
        public PruneEvent() { }
        public required string PruneType { get; set; }
        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUOM { get; set; }
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
