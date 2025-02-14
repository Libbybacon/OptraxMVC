using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowFlow.Models.Crops
{
    public class PlantAction
    {
        public PlantAction() { }

        public int ID { get; set; }

        public int PlantID { get; set; }

        public DateTimeOffset Date { get; set; }

        public required string ActionType { get; set; }

        public string? ActionSubType { get; set; }

        public int? TransferID { get; set; }

        public virtual PlantTransfer? Transfer { get; set; }
    }

    public class TransplantAction: PlantAction
    {
        public TransplantAction() { }

        public int NewContainerID { get; set; }
    }

    public class PruneAction : PlantAction
    {
        public PruneAction() { }
        public required string PruneType { get; set; }
    }

    public class TreatmentAction : PlantAction
    {
        public TreatmentAction() { }

        public int? InventoryItemID { get; set; }
        public required string TreatmentType { get; set; }
        public decimal? QuantityApplied { get; set; }
        public string? QuantityUOM { get; set; }
        public virtual Inventory.InventoryStockItem? InventoryItem { get; set; }
    }

    public class PestControlAction : PlantAction
    {
        public PestControlAction() { }
        public int? InventoryItemID { get; set; }
        public required string PestControlType { get; set; }
        public decimal? PestControlAmount { get; set; }
        public string? PestControlUOM { get; set; }
        public virtual Inventory.InventoryStockItem? InventoryItem { get; set; }
    }
}
