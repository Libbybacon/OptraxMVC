﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.BaseClasses;
using OptraxDAL.Models.Inventory;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("PlantEvents", Schema = "Grow")]
    public abstract class PlantEvent : BaseClass
    {
        public PlantEvent() { }
        public int PlantID { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        [MaxLength(25)]
        public string EventType { get; set; } = string.Empty;

        [MaxLength(25)]
        public string? EventSubType { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Notes { get; set; }

        [BindNever]
        [ValidateNever]
        public virtual Plant Plant { get; set; } = new();
        public virtual AppUser User { get; set; } = new();
    }

    [Table("PlantEvents")]
    public class TransferEvent : PlantEvent
    {
        public TransferEvent()
        {
            EventType = "Transfer";
        }
        public int TransferID { get; set; }

        [BindProperty]
        public virtual InventoryTransfer Transfer { get; set; } = new();
    }

    [Table("PlantEvents")]
    public class TransplantEvent : PlantEvent
    {
        public TransplantEvent()
        {
            EventType = "Transplant";
        }

        [Required]
        public int NewContainerID { get; set; }
        public virtual ContainerType NewContainer { get; set; } = new();
    }

    [Table("PlantEvents")]
    public class TreatmentEvent : PlantEvent
    {
        public TreatmentEvent()
        {
            EventType = "Treatment";
        }

        [MaxLength(25)]
        public required string TreatmentType { get; set; }
        public int? ProductID { get; set; }
        public decimal? QuantityApplied { get; set; }

        [MaxLength(20)]
        public string? QuantityUoM { get; set; }
        public virtual Consumable? Product { get; set; }
    }

    [Table("PlantEvents")]
    public class GrowthEvent : PlantEvent
    {
        public GrowthEvent()
        {
            EventType = "Growth";
        }
        public required string NewPhase { get; set; }
    }

    [Table("PlantEvents")]
    public class PruneEvent : PlantEvent
    {
        public PruneEvent()
        {
            EventType = "Prune";
        }
        public required string PruneType { get; set; }
        public decimal? WasteQuantity { get; set; }
        public string? WasteQuantityUOM { get; set; }
    }

    public enum TreatmentType
    {
        Water,
        Fertilize,
        Flush,
        PestControl,
        MoldControl,
        WeedControl
    }

    public enum PruneType
    {
        Deadhead,
        Defoliate,
        Dethorn,
        Trellis,
    }
}