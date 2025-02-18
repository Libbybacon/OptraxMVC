﻿using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Inventory
{
    [Table("InventoryLocation")]
    public abstract class InventoryLocation
    {
        public InventoryLocation() { }

        public int ID { get; set; }
        public int? ParentID { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public bool Active { get; set; } = true;

        public virtual InventoryLocation? Parent { get; set; } = null;
        public virtual ICollection<InventoryLocation> Children { get; set; } = [];
        public virtual ICollection<StockItem> StockItems { get; set; } = [];


        [InverseProperty(nameof(InventoryTransfer.Origin))]
        public virtual ICollection<InventoryTransfer> TransfersOut { get; set; } = [];

        [InverseProperty(nameof(InventoryTransfer.Destination))]
        public virtual ICollection<InventoryTransfer> TransfersIn { get; set; } = [];
    }

    [Table("InventoryLocation")]
    public class ContainerLocation : InventoryLocation
    {
        public ContainerLocation() { }

        public int ContainerTypeID { get; set; }
        public new required string Description { get; set; }

        public required ContainerType ContainerType { get; set; }
    }

    [Table("InventoryLocation")]
    public class RoomLocation : InventoryLocation
    {
        public RoomLocation() { }

        public virtual ICollection<Crop> Crops { get; set; } = [];
    }

    [Table("InventoryLocation")]
    public class BuildingLocation : InventoryLocation
    {
        public BuildingLocation() { }

        public int AddressID { get; set; }
        public virtual required Address Address { get; set; }
        //public virtual required BuildingAddress Address { get; set; }
    }

    [Table("InventoryLocation")]
    public class OffsiteLocation : InventoryLocation
    {
        public OffsiteLocation() { }

        public new required string Description { get; set; }
    }

    public enum LocationType
    {
        Container,
        Room,
        Building,
        Outdoor,
        OffSite
    }
}
