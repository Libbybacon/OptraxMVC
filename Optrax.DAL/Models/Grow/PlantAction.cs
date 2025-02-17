using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantActions")]    
    public abstract class PlantAction : ActionBase
    {
        public PlantAction() { }

        public int PlantID { get; set; }

        public required string ActionType { get; set; }

        public string? ActionSubType { get; set; }

        public required virtual Plant Plant { get; set; }
    }

    [Table("PlantActions")]
    public class TransferAction: PlantAction
    {
        public TransferAction() { }

        public int TransferID { get; set; }

        public required virtual PlantTransfer Transfer { get; set; }
    }

    [Table("PlantActions")]
    public class PruneAction : PlantAction
    {
        public PruneAction() { }
        public required string PruneType { get; set; }
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

    [Table("PlantActions")]
    public class TreatmentAction : PlantAction
    {
        public TreatmentAction() { }

        public required string TreatmentType { get; set; }
        public int? InventoryItemID { get; set; }
        public decimal? QuantityApplied { get; set; }
        public string? QuantityUOM { get; set; }
        public virtual Inventory.InventoryStockItem? InventoryItem { get; set; }
    }

    public enum TreatmentType
    {
        Water,
        Feed,
        Flush,
        PestControl,
        MoldControl
    }
}
