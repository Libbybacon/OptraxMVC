﻿using OptraxDAL.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptraxDAL.Models.Grow
{
    [Table("Strains", Schema = "Grow")]
    public class Strain : TrackingBaseDetails
    {
        public Strain() { }

        [Required]
        [MaxLength(10)]
        public string StrainType { get; set; } = string.Empty;
        public int? Generation { get; set; }
        public int? OriginID { get; set; }

        [MaxLength(50)]
        public string? OriginType { get; set; }

        public virtual ICollection<Crop> Crops { get; set; } = [];
        public virtual ICollection<StrainRelationship> Parents { get; set; } = [];
        public virtual ICollection<StrainRelationship> Children { get; set; } = [];

        public string GetParentNames()
        {
            if (Parents.Count > 0)
            {
                return string.Join(", ", Parents.Select(p => p.ParentStrain.Name).ToList());
            }
            return string.Empty;
        }

        public List<Strain> GetAllChildren()
        {
            if (Children.Count > 0)
            {
                return [.. Children.Select(c => c.ChildStrain)];
            }
            return [];
        }
    }

    public class StrainRelationship
    {
        public StrainRelationship() { }

        public int ChildID { get; set; }
        public int ParentID { get; set; }

        public Strain ChildStrain { get; set; } = null!;
        public Strain ParentStrain { get; set; } = null!;
    }

    public enum StrainTypes
    {
        Indica,
        Sativa,
        Hybrid
    }

    public enum OriginTypes
    {
        InHouse,
        External
    }
}
